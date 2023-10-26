import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControl, FormControlLabel, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";

function AddZorgkundige() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [voornaam, setVoornaam] = useState('');
  const [achternaam, setAchternaam] = useState('');
  const [regimeTypeId, setRegimeTypeId] = useState('');
  const [isVasteNacht, setIsVasteNacht] = useState(false);
  const [data, setData] = useState([]);
  const [regimeTypeData, setRegimeTypeData] = useState([]);

  useEffect(() => {
    getData();
    getRegimeTypeData();
  }, []);

  const getData = () => {
    const API = 'https://localhost:8000/api/Zorgkundigen'
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

  const handleCreate = () => {
    const API = 'https://localhost:8000/api/Zorgkundigen';
    const data =
    {
      "voornaam": voornaam,
      "achternaam": achternaam,
      "regimeId": regimeTypeId,
      "isVasteNacht": isVasteNacht
    }
    axios.post(API, data)
      .then(() => {
        getData();
        toast.success('Zorgkundige is toegevoegd');
        clear();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
        clear();
      })
  }

  const handleActiveChange = (e) => {
    if (e.target.checked) {
      setIsVasteNacht(true);
    }
    else {
      setIsVasteNacht(false);
    }
  }

  const clear = () => {
    setVoornaam('');
    setAchternaam('');
    setRegimeTypeId('');
    setIsVasteNacht(false);
  }

  const renderRegimeType = () => {
    return regimeTypeData.map((item) => (
      <MenuItem value={item.id}>{item.regime}</MenuItem>
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
              type="text"
              className="form-control"
              placeholder="Vul uw voornaam..."
              value={voornaam}
              onChange={(e) => setVoornaam(e.target.value)}
            />
            <TextField
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              placeholder="Vul uw achternaam..."
              value={achternaam}
              onChange={(e) => setAchternaam(e.target.value)}
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
              <Checkbox
                type="checkbox"
                checked={isVasteNacht === true ? true : false}
                value={isVasteNacht}
                onChange={(e) => handleActiveChange(e)}
              />
            } />
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

export default AddZorgkundige;