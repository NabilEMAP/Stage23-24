import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";

function EditNurse(props) {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [Id, editId] = useState('');
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
    const API = 'https://localhost:8000/api/Nurses'
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const getRegimeTypeData = () => {
    const API = 'https://localhost:8000/api/RegimeTypes'
    axios.get(API)
      .then((result) => {
        setRegimeTypeData(result.data);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleEdit = (id) => {
    handleShow();
    const API = `https://localhost:8000/api/Nurses/${id}`;
    axios.get(API)
      .then((result) => {
        setFirstName(result.data.firstName);
        setLastName(result.data.lastName);
        setIsFixedNight(result.data.isFixedNight);
        setRegimeTypeId(result.data.regimeTypeId);
        editId(id);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleUpdate = () => {
    const API = `https://localhost:8000/api/Nurses/${Id}`;
    const data =
    {
      "id": Id,
      "firstName": firstName,
      "lastName": lastName,
      "regimeId": regimeTypeId,
      "isFixedNight": isFixedNight
    }
    axios.put(API, data)
      .then(() => {
        toast.success('Zorgkundige is gewijzigd');
        getData();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
      })
  }

  const handleEditActiveChange = (e) => {
    if (e.target.checked) {
      setIsFixedNight(true);
    }
    else {
      setIsFixedNight(false);
    }
  }

  const renderRegimeType = () => {
    return regimeTypeData.map((item) => (
      <MenuItem value={item.id}>{item.name}</MenuItem>      
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
          <Modal.Title>Zorgkundige wijzigen</Modal.Title>
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
              type="text"
              className="form-control"
              placeholder="Voornaam"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
            <TextField
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              placeholder="Achternaam"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
            />
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Selecteer uw regime...</InputLabel>
              <Select
                value={regimeTypeId}
                onChange={(e) => setRegimeTypeId(e.target.value)}
              >
                {renderRegimeType()}
              </Select>
            </FormControl>
            <FormControlLabel label="Vaste Nacht" control={
              <Checkbox type="checkbox"
                checked={isFixedNight === true ? true : false}
                value={isFixedNight}
                onChange={(e) => handleEditActiveChange(e)}
              />
            } />
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

export default EditNurse;