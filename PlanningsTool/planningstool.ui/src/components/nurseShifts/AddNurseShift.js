import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";

function AddNurseShift() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [date, setDate] = useState('');
  const [nurseId, setNurseId] = useState('');
  const [shiftId, setShiftId] = useState('');
  const [data, setData] = useState([]);
  const [nurseData, setNurseData] = useState([]);
  const [shiftData, setShiftData] = useState([]);

  useEffect(() => {
    getData();
    getNurseData();
    getShiftData();
  }, []);

  const getData = () => {
    const API = 'https://localhost:8000/api/NurseShifts'
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

  const getShiftData = () => {
    const API = 'https://localhost:8000/api/Shifts'
    axios.get(API)
      .then((result) => {
        setShiftData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleCreate = () => {
    const API = 'https://localhost:8000/api/NurseShifts';
    const data =
    {
      "date": date,
      "nurseId": nurseId,
      "shiftId": shiftId,
      "teamplanId": 1 //ik ga die even op 1 houden (hardcoded)
    }
    axios.post(API, data)
      .then(() => {
        getData();
        toast.success('Nurse shift is toegevoegd');
        clear();
        handleClose();
        console.log(data);
      })
      .catch((error) => {
        toast.warning(`${error}`);
        console.log(data);
        clear();
      })
  }

  const clear = () => {
    setDate('');
    setNurseId('');
    setShiftId('');
  }

  const renderNurse = () => {
    return nurseData.map((item) => (
      <MenuItem value={item.id}>{
        item.firstName + ' ' +
        item.lastName + ' (' +
        item.regimeType.name + ')'
      }</MenuItem>
    ));
  }

  const renderShift = () => {
    return shiftData.map((item) => (
      <MenuItem value={item.id}>{
        item.shiftType.name + ' - ' +
        item.starttime + ' - ' +
        item.endtime
      }</MenuItem>
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
        Zorgkundige Shift toevoegen
      </Button>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Zorgkundige Shift toevoegen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Selecteer een zorgkundige...</InputLabel>
              <Select
                value={nurseId}
                onChange={(e) => setNurseId(e.target.value)}
              >
                {renderNurse()}
              </Select>
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Selecteer een shift...</InputLabel>
              <Select
                value={shiftId}
                onChange={(e) => setShiftId(e.target.value)}
              >
                {renderShift()}
              </Select>
            </FormControl>
            <TextField
              style={{ width: '75%' }}
              type="date"
              className="form-control"
              value={date}
              onChange={(e) => setDate(e.target.value)}
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

export default AddNurseShift;