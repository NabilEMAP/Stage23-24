import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";

function EditZorgkundigeShift(props) {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [Id, editId] = useState('');
  const [datum, setDatum] = useState('');
  const [zorgkundigeId, setZorgkundigeId] = useState('');
  const [shiftId, setShiftId] = useState('');
  const [data, setData] = useState([]);
  const [zorgkundigeData, setZorgkundigeData] = useState([]);
  const [shiftData, setShiftData] = useState([]);

  useEffect(() => {
    getData();
    getZorgkundigeData();
    getShiftData();
  }, []);

  const getData = () => {
    const API = 'https://localhost:8000/api/ZorgkundigeShifts'
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getZorgkundigeData = () => {
    const API = 'https://localhost:8000/api/Zorgkundigen'
    axios.get(API)
      .then((result) => {
        setZorgkundigeData(result.data);
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

  const handleEdit = (id) => {
    handleShow();
    const API = `https://localhost:8000/api/ZorgkundigeShifts/${id}`;
    axios.get(API)
      .then((result) => {
        setDatum(result.data.datum);
        setZorgkundigeId(result.data.zorgkundigeId);
        setShiftId(result.data.shiftId);
        editId(id);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleUpdate = () => {
    const API = `https://localhost:8000/api/ZorgkundigeShifts/${Id}`;
    const data =
    {
      "id": Id,
      "datum": datum,
      "zorgkundigeId": zorgkundigeId,
      "shiftId": shiftId,
      "teamplanningId": 1 //ik ga die even op 1 houden (hardcoded)
    }
    axios.put(API, data)
      .then((result) => {
        toast.success('Zorgkundige is gewijzigd');
        getData();
        handleClose();
        console.log(data);
      })
      .catch((error) => {
        toast.warning(`${error}`);
        console.log(data);
      })
  }

  const renderZorgkundige = () => {
    return zorgkundigeData.map((item) => (
      <MenuItem value={item.id}>{
        item.voornaam + ' ' +
        item.achternaam + ' (' +
        item.regimeType.regime + ')'
      }</MenuItem>
    ));
  }

  const renderShift = () => {
    return shiftData.map((item) => (
      <MenuItem value={item.id}>{
        item.shiftType.shift + ' - ' +
        item.starttijd + ' - ' +
        item.eindtijd
      }</MenuItem>
    ));
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
              <InputLabel>Selecteer een zorgkundige...</InputLabel>
              <Select
                value={zorgkundigeId}
                onChange={(e) => setZorgkundigeId(e.target.value)}
              >
                {renderZorgkundige()}
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
              value={datum}
              onChange={(e) => setDatum(e.target.value)}
            />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button variant="contained" color="primary" onClick={handleUpdate}>
              Wijzigen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default EditZorgkundigeShift;