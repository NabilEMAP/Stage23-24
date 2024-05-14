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
  const [teamId, setTeamId] = useState('');
  const [teamData, setTeamData] = useState([]);

  useEffect(() => {
    getData();
    getTeamData();
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
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const getTeamData = () => {
    const API = `${API_BASE_URL}/Teams`;
    axios.get(API)
      .then((result) => {
        setTeamData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const getNurseData = (teamId) => {
    const API = `${API_BASE_URL}/Nurses?teamId=${teamId}`;
    axios.get(API)
      .then((result) => {
        setNurseData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const getShiftData = () => {
    const API = `${API_BASE_URL}/Shifts`;
    axios.get(API)
      .then((result) => {
        setShiftData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const formatTime = (timeString) => {
    const date = new Date(`2000-01-01T${timeString}`);
    return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  };

  const handleDelete = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/NurseShifts/${id}`;
    axios.get(API)
      .then((result) => {
        setDate(dayjs(result.data.date).format('DD/MM/YYYY'));
        const team = teamData.find((item) => item.id === result.data.nurse.teamId);
        setTeamId(team ? team.teamName : '');
        const nurse = nurseData.find((item) => item.id === result.data.nurseId);
        setNurseId(nurse ?
          nurse.firstName + " " +
          nurse.lastName + ' (' +
          nurse.regimeType.name + ') '
          : '');
        const shift = shiftData.find((item) => item.id === result.data.shiftId);
        setShiftId(shift ?
          shift.shiftType.name + ' - ' +
          formatTime(shift.starttime) + ' - ' +
          formatTime(shift.endtime)
          : '');
        editId(id);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const handlePostDelete = () => {
    const API = `${API_BASE_URL}/NurseShifts/${Id}`;
    axios.delete(API)
      .then(() => {
        toast.error('Nurse shift is verwijderd');
        props.onUpdate();
        if (props.onDeleteComplete) {
          props.onDeleteComplete();
        }
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
      })
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
            <FormControl style={{ width: '75%' }}>
              <h4>Team</h4>
              <p id="team" value={teamId}>{teamId}</p>
              <h4>Zorgkundige</h4>
              <p id="nurse" value={nurseId}>{nurseId}</p>
              <h4>Shift</h4>
              <p id="shift" value={shiftId}>{shiftId}</p>
              <h4>Datum</h4>
              <p id="date" value={date}>{date}</p>
            </FormControl>
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button id="submitNurseShiftForm" variant="contained" color="error" onClick={handlePostDelete}>
              Verwijderen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteNurseShift;
