import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../../config";

function DeleteNurse(props) {
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
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handleDelete = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/Nurses/${id}`;
    axios.get(API)
      .then((result) => {
        setFirstName(result.data.firstName);
        setLastName(result.data.lastName);
        setRegimeTypeId(result.data.regimeTypeId);
        setIsFixedNight(result.data.isVasteNacht);
        editId(id);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handlePostDelete = () => {
    const API = `${API_BASE_URL}/Nurses/${Id}`;
    axios.delete(API)
      .then(() => {
        toast.error('Zorgkundige is verwijderd');
        props.onUpdate();
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
      <MenuItem key={item.id} value={item.id}>
        {item.name}
      </MenuItem>
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
          <Modal.Title>Zorgkundige verwijderen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <h6>Ben je zeker dat je deze zorgkundige wilt verwijderen?</h6>
            <TextField
              style={{ width: '75%' }}
              required
              label="Voornaam"
              type="text"
              className="form-control"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
              disabled
            />
            <TextField
              style={{ width: '75%' }}
              required
              label="Voornaam"
              type="text"
              className="form-control"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
              disabled
            />
            <FormControl style={{ width: '75%' }} disabled>
              <InputLabel>Regime *</InputLabel>
              <Select
                required
                label="Regime"
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
                disabled
              />
            } />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button id="submitNurseForm" variant="contained" color="error" onClick={handlePostDelete}>
              Verwijderen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteNurse;
