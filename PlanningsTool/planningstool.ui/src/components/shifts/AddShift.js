import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack } from "@mui/material";
import { TimePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

function AddShift({ dataChanged }) {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [starttime, setStarttime] = useState('');
  const [endtime, setEndtime] = useState('');
  const [shiftTypeId, setShiftTypeId] = useState('');
  const [data, setData] = useState([]);
  const [shiftTypeData, setShiftTypeData] = useState([]);

  useEffect(() => {
    getData();
    getShiftTypeData();
  }, [dataChanged]);

  const getData = () => {
    const API = `${API_BASE_URL}/Shifts`;
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getShiftTypeData = () => {
    const API = `${API_BASE_URL}/ShiftTypes`;
    axios.get(API)
      .then((result) => {
        setShiftTypeData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleCreate = () => {
    const API = `${API_BASE_URL}/Shifts`;
    const data =
    {
      "starttime": starttime,
      "endtime": endtime,
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
        if (error.response.status === 400) {
          toast.warning('Zie dat de gegevens correct ingevuld zijn');
        } else {
          toast.warning(`${error.response.data.Message}`);
        }        
        clear();
      })
      console.log(data);
      console.log(JSON.stringify(error));
    console.log(data);
    dataChanged(true);
  }

  const clear = () => {
    //setStarttime('');
    //setEndtime('');
    setShiftTypeId('');
  }

  const renderShiftType = () => {
    return shiftTypeData.map((item) => (
      <MenuItem key={item.id} value={item.id}>
        {item.name}
      </MenuItem>
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
              <InputLabel>Shift *</InputLabel>
              <Select
                required
                label="Shift"
                value={shiftTypeId}
                onChange={(e) => setShiftTypeId(e.target.value)}
              >
                {renderShiftType()}
              </Select>
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <TimePicker slotProps={{ textField: { error: false } }}
                required
                label="Starttijd *"
                ampm={false}
                onChange={(e) => setStarttime(dayjs(e).format('HH:mm:ss'))}
              />
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <TimePicker slotProps={{ textField: { error: false } }}
                required
                label="Eindtijd *"
                ampm={false}
                onChange={(e) => setEndtime(dayjs(e).format('HH:mm:ss'))}
              />
            </FormControl>
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