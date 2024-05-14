import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, Stack } from "@mui/material";
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
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const getRegimeTypeData = () => {
    const API = `${API_BASE_URL}/RegimeTypes`;
    axios.get(API)
      .then((result) => {
        setRegimeTypeData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const handleDelete = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/Nurses/${id}`;
    axios.get(API)
      .then((result) => {
        setFirstName(result.data.firstName);
        setLastName(result.data.lastName);
        const regime = regimeTypeData.find((item) => item.id === result.data.regimeTypeId);
        setRegimeTypeId(regime ? regime.name : '');
        setIsFixedNight(result.data.isFixedNight ? 'Ja' : 'Nee');
        editId(id);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const handlePostDelete = () => {
    const API = `${API_BASE_URL}/Nurses/${Id}`;
    axios.delete(API)
      .then(() => {
        toast.error('Zorgkundige is verwijderd');
        handleClose();
        props.onUpdate();
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
            <FormControl style={{ width: '75%' }}>
              <h4>Voornaam</h4>
              <p id="firstName" value={firstName}>{firstName}</p>
              <h4>Achternaam</h4>
              <p id="lastName" value={lastName}>{lastName}</p>
              <h4>Regime</h4>
              <p id="regime" value={regimeTypeId}>{regimeTypeId}</p>
              <h4>Vaste Nacht?</h4>
              <p id="fixedNight" value={isFixedNight}>{isFixedNight}</p>
            </FormControl>
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
