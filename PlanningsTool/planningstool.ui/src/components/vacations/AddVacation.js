import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";

function AddVacation() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [startdate, setStartdate] = useState('');
  const [enddate, setEnddate] = useState('');
  const [nurseId, setNurseId] = useState('');
  const [vacationTypeId, setVacationTypeId] = useState('');
  const [reason, setReason] = useState('');
  const [data, setData] = useState([]);
  const [nurseData, setNurseData] = useState([]);
  const [vacationTypeData, setVacationTypeData] = useState([]);

  useEffect(() => {
    getData();
    getNurseData();
    getVacationTypeData();
  }, []);

  const getData = () => {
    const API = 'https://localhost:8000/api/Vacations/details'
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getNurseData = () => {
    const API = 'https://localhost:8000/api/Nurses'
    axios.get(API)
      .then((result) => {
        setNurseData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getVacationTypeData = () => {
    const API = 'https://localhost:8000/api/VacationTypes'
    axios.get(API)
      .then((result) => {
        setVacationTypeData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleCreate = () => {
    if (!startdate) { toast.warning('Startdatum mag niet leeg zijn'); return; }
    if (!enddate) { toast.warning('Einddatum mag niet leeg zijn'); return; }
    if (!nurseId) { toast.warning('Zorgkundige mag niet leeg zijn'); return; }
    if (!vacationTypeId) { toast.warning('Verlof mag niet leeg zijn'); return; }

    const API = 'https://localhost:8000/api/Vacations';
    const data =
    {
      "startdate": startdate,
      "enddate": enddate,
      "nurseId": nurseId,
      "vacationTypeId": vacationTypeId,
      "reason": reason
    }
    axios.post(API, data)
      .then(() => {
        getData();
        toast.success('Verlof is toegevoegd');
        clear();
        handleClose();
      })
      .catch((error) => {
        if (error.response) {
          toast.warning('Zie dat de gegevens correct ingevuld zijn');
        } else {
          toast.warning(`${error.response.data.Message}`);
        }
        console.log(data);
        console.log(JSON.stringify(error));
        clear();
      })
  }

  const clear = () => {
    setStartdate('');
    setEnddate('');
    setNurseId('');
    setVacationTypeId('');
    setReason('');
  }

  const renderNurse = () => {
    return nurseData.map((item) => (
      <MenuItem value={item.id}>{item.firstName + ' ' + item.lastName}</MenuItem>
    ));
  }

  const renderVacationsType = () => {
    return vacationTypeData.map((item) => (
      <MenuItem value={item.id}>{item.name}</MenuItem>
    ));
  }

  return (
    <>
      <Button
        variant="contained"
        style={{ float: 'right' }}
        color="success"
        onClick={() => handleShow()}
      >
        Verlof toevoegen
      </Button>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Verlof toevoegen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Zorgkundige *</InputLabel>
              <Select
                required
                label="Zorgkundige"
                value={nurseId}
                onChange={(e) => setNurseId(e.target.value)}
              >
                {renderNurse()}
              </Select>
            </FormControl>
            <TextField
              style={{ width: '75%' }}
              type="date"
              className="form-control"
              value={startdate}
              onChange={(e) => setStartdate(e.target.value)}
            />
            <TextField
              style={{ width: '75%' }}
              type="date"
              className="form-control"
              value={enddate}
              onChange={(e) => setEnddate(e.target.value)}
            />
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Verlof *</InputLabel>
              <Select
                required
                label="Verlof"
                value={vacationTypeId}
                onChange={(e) => setVacationTypeId(e.target.value)}
              >
                {renderVacationsType()}
              </Select>
            </FormControl>
            <TextField
              label="Reden"
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              value={reason}
              multiline={true}
              minRows={6}
              onChange={(e) => setReason(e.target.value)}
            />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button variant="contained" color="success" onClick={handleCreate}>
              Toevoegen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );

}
export default AddVacation;