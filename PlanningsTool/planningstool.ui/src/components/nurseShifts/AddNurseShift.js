import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

function AddNurseShift(props) {
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
    const API = `${API_BASE_URL}/NurseShifts`;
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getNurseData = () => {
    const API = `${API_BASE_URL}/Nurses`;
    axios.get(API)
      .then((result) => {
        setNurseData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getShiftData = () => {
    const API = `${API_BASE_URL}/Shifts`;
    axios.get(API)
      .then((result) => {
        setShiftData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleCreate = () => {
    const API = `${API_BASE_URL}/NurseShifts`;
    const data =
    {
      "date": date,
      "nurseId": nurseId,
      "shiftId": shiftId,
      "teamplanId": 1 //ik ga die even op 1 houden (hardcoded)
    }
    axios.post(API, data)
      .then(() => {
        props.onUpdate();
        toast.success('Nurse shift is toegevoegd');
        clear();
        handleClose();
        console.log(data);
      })
      .catch((error) => {
        if (error.response.status === 400) {
          toast.warning('Zie dat de gegevens correct ingevuld zijn');
        } else {
          toast.warning(`${error.response.data.Message}`);
        }
        console.log(JSON.stringify(error));
        clear();
      })
    console.log(data);
  }

  const clear = () => {
    //setDate('');
    setNurseId('');
    setShiftId('');
  }

  const renderNurse = () => {
    return nurseData.map((item) => (
      <MenuItem key={item.id} value={item.id}>{
        item.firstName + ' ' +
        item.lastName + ' (' +
        item.regimeType.name + ')'
      }</MenuItem>
    ));
  }

  const renderShift = () => {
    return shiftData.map((item) => (
      <MenuItem key={item.id} value={item.id}>{
        item.shiftType.name + ' - ' +
        formatTime(item.starttime) + ' - ' +
        formatTime(item.endtime)
      }</MenuItem>
    ));
  }

  const formatTime = (timeString) => {
    const date = new Date(`2000-01-01T${timeString}`);
    return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  };

  return (
    <>
      <Button
        id="createNurseShift"
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
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Shift *</InputLabel>
              <Select
                required
                label="Shift"
                value={shiftId}
                onChange={(e) => setShiftId(e.target.value)}
              >
                {renderShift()}
              </Select>
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <DatePicker slotProps={{ textField: { error: false } }}
                required
                label="Datum *"
                onChange={(e) => setDate(dayjs(e).format('YYYY-MM-DD'))}
              />
            </FormControl>
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button id="submitNurseShiftForm" variant="contained" color="success" onClick={handleCreate}>
              Toevoegen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default AddNurseShift;