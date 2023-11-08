import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, InputLabel, MenuItem, Select, Stack } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { DatePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

function DeleteNurseShift(props) {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [Id, editId] = useState('');
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

  const handleDelete = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/NurseShifts/${id}`;
    axios.get(API)
      .then((result) => {
        setDate(result.data.date);
        setNurseId(result.data.nurseId);
        setShiftId(result.data.shiftId);
        editId(id);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handlePostDelete = () => {
    const API = `${API_BASE_URL}/NurseShifts/${Id}`;
    axios.delete(API)
      .then(() => {
        toast.error('Nurse shift is verwijderd');
        getData();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
      })
    props.dataChanged(true);
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
        item.starttime + ' - ' +
        item.endtime
      }</MenuItem>
    ));
  }

  return (
    <>
      <IconButton
        size="medium"
        color="error"
        onClick={() => handleDelete(props.id)}
      >
        <FontAwesomeIcon icon={faTrash} />
      </IconButton>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Zorgkundige Shift verwijderen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <h6>Ben je zeker dat je deze zorgkundige shift wilt verwijderen?</h6>
            <FormControl style={{ width: '75%' }} disabled>
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
            <FormControl style={{ width: '75%' }} disabled>
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
            <FormControl style={{ width: '75%' }} >
              <DatePicker slotProps={{ textField: { error: false } }}
                required
                label="Datum *"
                value={dayjs(date)}
                onChange={(e) => setDate(dayjs(e).format('YYYY-MM-DD'))}
                disabled
              />
            </FormControl>
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button variant="contained" color="error" onClick={handlePostDelete}>
              Verwijderen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteNurseShift;
