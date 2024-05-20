import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

function AddNurseShift(props) {
  const { selectedDateSlot, teamplanId } = props;
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [date, setDate] = useState('');
  const [nurseId, setNurseId] = useState('');
  const [shiftId, setShiftId] = useState('');
  const [nurseData, setNurseData] = useState([]);
  const [shiftData, setShiftData] = useState([]);
  const [teamId, setTeamId] = useState('');

  useEffect(() => {
      getShiftData();
      if (selectedDateSlot) {
          setDate(dayjs(selectedDateSlot.start));
      }
      if (teamplanId) {
          getTeamplanData(teamplanId);
      }
      getNurseData(teamId);
  }, []);

  const getTeamplanData = (teamplanId) => {
      const API = `${API_BASE_URL}/Teamplans/${teamplanId}`;
      axios.get(API)
          .then((result) => {
              setTeamId(result.data.teamId);              
          })
          .catch((error) => {
              toast.warning(error.message + ': ' + API.split('/api/')[1]);
          });
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

  const handleCreate = () => {
      const errorMessages = [];

      if (!date) errorMessages.push('Datum mag niet leeg zijn');
      if (!nurseId) errorMessages.push('Zorgkundige mag niet leeg zijn');
      if (!shiftId) errorMessages.push('Shift mag niet leeg zijn');

      if (errorMessages.length > 0) {
          const errorMessage = errorMessages.join('\n');
          toast.warning(errorMessage);
          return;
      }

      const API = `${API_BASE_URL}/NurseShifts`;
      const data = {
          "date": dayjs(date).format('YYYY-MM-DD'),
          "teamId": teamId,
          "nurseId": nurseId,
          "shiftId": shiftId,
          "teamplanId": teamplanId,
      }
      axios.post(API, data)
          .then(() => {
              toast.success('Nurse shift is toegevoegd');
              clear();
              handleClose();
              props.onUpdate();
              if (props.onAddComplete) {
                  props.onAddComplete();
              }
          })
          .catch((error) => {
              if (error.response.status === 400) {
                  toast.warning('Zie dat de gegevens correct ingevuld zijn');
              } else {
                  toast.warning(`${error.response.data.Message}`);
              }
              clear();
          })
  }

  const clear = () => {
      setNurseId('');
      setShiftId('');
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


  return (
      <>
          <Button id="createShift" variant="contained" style={{ float: 'right' }} color="success" onClick={handleShow}>
              Zorgkundige shift toevoegen
          </Button>
          <Modal show={show} onHide={handleClose}>
              <Modal.Header closeButton>
                  <Modal.Title>Zorgkundige shift toevoegen</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                  <Stack direction="column" justifyContent="center" alignItems="center" spacing={4}>
                      <FormControl style={{ width: '75%' }}>
                          <DatePicker slotProps={{ textField: { error: false } }}
                              required
                              id="txtInputDate"
                              label="Datum *"
                              value={date}
                              onChange={(e) => setDate(dayjs(e))}
                          />
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
                  </Stack>
              </Modal.Body>
              <Modal.Footer>
                  <Stack direction="row" alignItems="center" spacing={2}>
                      <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
                          Terug
                      </Button>
                      <Button id="submitShiftForm" variant="contained" color="success" onClick={handleCreate}>
                          Toevoegen
                      </Button>
                  </Stack>
              </Modal.Footer>
          </Modal>
      </>
  );
}

export default AddNurseShift;