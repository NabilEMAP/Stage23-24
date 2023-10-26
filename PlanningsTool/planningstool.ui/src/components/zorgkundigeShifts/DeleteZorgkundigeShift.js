import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";

function DeleteZorgkundigeShift(props) {
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

  const handleDelete = (id) => {
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

  const handlePostDelete = () => {
    const API = `https://localhost:8000/api/ZorgkundigeShifts/${Id}`;
    axios.delete(API)
      .then(() => {
        toast.error('Zorgkundige shift is verwijderd');
        getData();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
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
              <InputLabel>Selecteer een zorgkundige...</InputLabel>
              <Select
                value={zorgkundigeId}
                onChange={(e) => setZorgkundigeId(e.target.value)}
              >
                {renderZorgkundige()}
              </Select>
            </FormControl>
            <FormControl style={{ width: '75%' }} disabled>
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
              disabled
            />
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

export default DeleteZorgkundigeShift;
