import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { API_BASE_URL } from "../../config";

function AddNurse(props) {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [regimeTypeId, setRegimeTypeId] = useState('');
  const [isFixedNight, setIsFixedNight] = useState(false);
  const [data, setData] = useState([]);
  const [regimeTypeData, setRegimeTypeData] = useState([]);

  useEffect(() => {
    getData();
    getRegimeTypeData();
  }, []);

  const getData = () => {
    const API = `${API_BASE_URL}/Nurses`;
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getRegimeTypeData = () => {
    const API = `${API_BASE_URL}/RegimeTypes`;
    axios.get(API)
      .then((result) => {
        setRegimeTypeData(result.data);
        //setRegimeTypeId('1'); //default value
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleCreate = () => {
    const errorMessages = [];

    if (!firstName) errorMessages.push('Voornaam mag niet leeg zijn');
    if (!lastName) errorMessages.push('Achternaam mag niet leeg zijn');
    if (!regimeTypeId) errorMessages.push('Regime mag niet leeg zijn');

    if (errorMessages.length > 0) {
      const errorMessage = errorMessages.join('\n');
      toast.warning(errorMessage);
      return;
    }

    const API = `${API_BASE_URL}/Nurses`;
    const data = 
    {
      "firstName": firstName,
      "lastName": lastName,
      "regimeTypeId": regimeTypeId,
      "isFixedNight": isFixedNight,
      "teamId": props.teamId
  };
    axios.post(API, data)
      .then(() => {
        props.onUpdate();
        toast.success('Zorgkundige is toegevoegd');
        clear();
        handleClose();
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

  const handleActiveChange = (e) => {
    if (e.target.checked) {
      setIsFixedNight(true);
    }
    else {
      setIsFixedNight(false);
    }
  }

  const clear = () => {
    setFirstName('');
    setLastName('');
    setIsFixedNight(false);
  }

  const renderRegimeType = () => {
    return regimeTypeData.map((item) => (
      <MenuItem key={item.id} value={item.id}>
        {item.name}
      </MenuItem>
    ));
  }

  return (
    <>
      <Button
        id="createNurse"
        variant="contained"
        style={{ float: 'right' }}
        color="success"
        onClick={() => handleShow()}
      >
        Zorgkundige toevoegen
      </Button>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Zorgkundige toevoegen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <TextField
              style={{ width: '75%' }}
              required
              id="txtInputFirstname"
              label="Voornaam"
              type="text"
              className="form-control"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
            <TextField
              style={{ width: '75%' }}
              required
              id="txtInputLastname"
              label="Achternaam"
              type="text"
              className="form-control"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
            />
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Regime *</InputLabel>
              <Select
                required
                id="selectRegime"
                label="Regime"
                value={regimeTypeId}
                onChange={(e) => setRegimeTypeId(e.target.value)}
              >
                {renderRegimeType()}
              </Select>
            </FormControl>
            <FormControlLabel label="Vaste Nacht" control={
              <Checkbox
                id="fixedNightInput"
                type="checkbox"
                checked={isFixedNight === true ? true : false}
                value={isFixedNight}
                onChange={(e) => handleActiveChange(e)}
              />
            } />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button id="submitNurseForm" variant="contained" color="success" onClick={handleCreate}>
              Toevoegen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default AddNurse;