import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";

function AddShift() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [starttijd, setStarttijd] = useState('');
  const [eindtijd, setEindtijd] = useState('');
  const [shiftTypeId, setShiftTypeId] = useState('');
  const [data, setData] = useState([]);
  const [shiftTypeData, setShiftTypeData] = useState([]);

  useEffect(() => {
    getData();
    getShiftTypeData();
  }, []);

  const getData = () => {
    const API = 'https://localhost:8000/api/Shifts'
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getShiftTypeData = () => {
    const API = 'https://localhost:8000/api/ShiftTypes'
    axios.get(API)
      .then((result) => {
        setShiftTypeData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleCreate = () => {
    const API = 'https://localhost:8000/api/Shifts';
    const data =
    {
      "starttijd": starttijd + ":00",
      "eindtijd": eindtijd + ":00",
      "shiftTypeId": shiftTypeId
    }
    axios.post(API, data)
      .then(() => {
        getData();
        toast.success('Shift is toegevoegd');
        clear();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
        clear();
      })
  }

  const clear = () => {
    setStarttijd('');
    setEindtijd('');
    setShiftTypeId('');
  }

  const renderShiftType = () => {
    return shiftTypeData.map((item) => (
      <MenuItem value={item.id}>{item.shift}</MenuItem>
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
        Shift toevoegen
      </Button>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Shift toevoegen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Shift</InputLabel>
              <Select
                value={shiftTypeId}
                onChange={(e) => setShiftTypeId(e.target.value)}
              >
                {renderShiftType()}
              </Select>
            </FormControl>
            <TextField
              style={{ width: '75%' }}
              type="time"
              className="form-control"
              value={starttijd}
              onChange={(e) => setStarttijd(e.target.value)}
            />
            <TextField
              style={{ width: '75%' }}
              type="time"
              className="form-control"
              value={eindtijd}
              onChange={(e) => setEindtijd(e.target.value)}
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
export default AddShift;