import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, IconButton, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../../config";

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

  const handleEdit = (id) => {
    handleShow();
    const API = `${API_BASE_URL}/Nurses/${id}`;
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
    const errorMessages = [];

    if (!firstName) errorMessages.push('Voornaam mag niet leeg zijn');
    if (!lastName) errorMessages.push('Achternaam mag niet leeg zijn');
    if (!regimeTypeId) errorMessages.push('Regime mag niet leeg zijn');

    if (errorMessages.length > 0) {
      const errorMessage = errorMessages.join('\n');
      toast.warning(errorMessage);
      return;
    }

    const API = `${API_BASE_URL}/Nurses/${Id}`;
    const data =
    {
      "id": Id,
      "firstName": firstName,
      "lastName": lastName,
      "regimeTypeId": regimeTypeId,
      "isFixedNight": isFixedNight
    }
    axios.put(API, data)
      .then(() => {
        toast.success('Zorgkundige is gewijzigd');
        getData();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error.response.data.Message}`);
        console.log(JSON.stringify(error.response.data));
      })
    props.dataChanged(true);
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
              required
              label="Voornaam"
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
            <TextField
              required
              label="Achternaam"
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              value={lastName}
              onChange={(e) => setLastName(e.target.value)}
            />
            <FormControl style={{ width: '75%' }}>
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