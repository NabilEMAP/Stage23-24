import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, Stack } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../../config";

function DeleteTeam(props) {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [Id, editId] = useState('');
  const [teamName, setTeamName] = useState('');
  const [data, setData] = useState([]);

  useEffect(() => {
    getData();
  }, []);

  const getData = () => {
    const API = `${API_BASE_URL}/Teams`;
    axios.get(API)
      .then((result) => {
        setData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const handleDelete = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/Teams/${id}`;
    axios.get(API)
      .then((result) => {
        setTeamName(result.data.teamName);
        editId(id);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      })
  }

  const handlePostDelete = () => {
    const API = `${API_BASE_URL}/Teams/${Id}`;
    axios.delete(API)
      .then(() => {
        toast.error('Team is verwijderd');
        props.onUpdate();
        handleClose();
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
          <Modal.Title>Team verwijderen</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <h6>Ben je zeker dat je deze team wilt verwijderen?</h6>
            <FormControl style={{ width: '75%' }}>
              <h4>Teamnaam</h4>
              <p id="teamName" value={teamName}>{teamName}</p>
            </FormControl>
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button id="submitTeamForm" variant="contained" color="error" onClick={handlePostDelete}>
              Verwijderen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteTeam;
