import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { DatePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

function EditNurseShift(props) {
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

  const handleEdit = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/NurseShifts/${id}`;
    axios.get(API)
      .then((result) => {
        setDate(result.data.date);
        setTeamId(result.data.nurse.teamId);
        setNurseId(result.data.nurseId);
        setShiftId(result.data.shiftId);
        editId(id);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const handleUpdate = () => {
    const errorMessages = [];

    if (!date) errorMessages.push('Date mag niet leeg zijn');
    if (!teamId) errorMessages.push('Team mag niet leeg zijn');
    if (!nurseId) errorMessages.push('Zorgkundige mag niet leeg zijn');
    if (!shiftId) errorMessages.push('Shift mag niet leeg zijn');

    if (errorMessages.length > 0) {
      const errorMessage = errorMessages.join('\n');
      toast.warning(errorMessage);
      return;
    }

    const API = `${API_BASE_URL}/NurseShifts/${Id}`;
    const data =
    {
      "id": Id,
      "date": date,
      "teamId": teamId,
      "nurseId": nurseId,
      "shiftId": shiftId,
      "teamplanId": 1 //ik ga die even op 1 houden (hardcoded)
    }
    axios.put(API, data)
      .then(() => {
        toast.success('Zorgkundige is gewijzigd');
        props.onUpdate();
        if (props.onEditComplete) {
          props.onEditComplete();
        }
        handleClose();
      })
      .catch((error) => {
        if (error.response.status === 400) {
          toast.warning('Zie dat de gegevens correct ingevuld zijn');
        } else {
          toast.warning(`${error.response.data.Message}`);
        }
      })
  }

  const renderTeam = () => {
    return teamData.map((item) => (
      <MenuItem key={item.id} value={item.id}>
        {item.teamName}
      </MenuItem>
    ));
  }

  const renderNurse = () => {
    const filteredNurses = nurseData.filter(nurse => nurse.teamId === teamId);
    return filteredNurses.map((item) => (
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

  const handleTeamChange = (e) => {
    const selectedTeamId = e.target.value;
    setTeamId(selectedTeamId);
    setNurseId('');
    getNurseData(selectedTeamId);
  }

  return (
    <>
      <IconButton
        size="medium"
        color="primary"
        onClick={() => handleEdit(props.id)}
      >
        <FontAwesomeIcon icon={faPen} />
      </IconButton>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Zorgkundige Shift wijzigen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Teams *</InputLabel>
              <Select
                required
                id="selectTeam"
                label="Team"
                value={teamId}
                onChange={handleTeamChange}
              >
                {renderTeam()}
              </Select>
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Zorgkundige *</InputLabel>
              <Select
                required
                id="selectNurse"
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
                id="selectShift"
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
                id="txtInputDate"
                label="Datum *"
                value={dayjs(date)}
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
            <Button id="submitNurseShiftForm" variant="contained" color="primary" onClick={handleUpdate}>
              Wijzigen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default EditNurseShift;