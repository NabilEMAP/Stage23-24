import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../../config";

function EditTeam(props) {
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

  const handleEdit = (id) => {
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

  const handleUpdate = () => {
    const errorMessages = [];

    if (!teamName) errorMessages.push('Titel mag niet leeg zijn');

    if (errorMessages.length > 0) {
      const errorMessage = errorMessages.join('\n');
      toast.warning(errorMessage);
      return;
    }

    const API = `${API_BASE_URL}/Teams/${Id}`;
    const data =
    {
      "id": Id,
      "teamName": teamName,
    }
    axios.put(API, data)
      .then(() => {
        toast.success('Team is gewijzigd');
        handleClose();
        props.onUpdate();
      })
      .catch((error) => {
        if (error.response.status === 400) {
          toast.warning('Zie dat de gegevens correct ingevuld zijn');
        } else {
          toast.warning(`${error.response.data.Message}`);
        }
      })
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
          <Modal.Title>Team wijzigen</Modal.Title>
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
              id="txtInputTeamName"
              label="Teamnaam"
              type="text"
              className="form-control"
              value={teamName}
              onChange={(e) => setTeamName(e.target.value)}
            />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button id="submitTeamForm" variant="contained" color="primary" onClick={handleUpdate}>
              Wijzigen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default EditTeam;