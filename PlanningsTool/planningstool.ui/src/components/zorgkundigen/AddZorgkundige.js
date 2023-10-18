import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControlLabel, Stack, TextField } from "@mui/material";

function AddZorgkundige() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [voornaam, setVoornaam] = useState('');
  const [achternaam, setAchternaam] = useState('');
  const [isVasteNacht, setIsVasteNacht] = useState(false);
  const [data, setData] = useState([]);

  useEffect(() => {
    getData();
  }, [data]);

  const getData = () => {
    const API = 'https://localhost:8000/api/Zorgkundigen/details'
    axios.get(API)
      .then((result) => {
        setData(result.data);
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
        toast.error(error);
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
    setIsVasteNacht(false);
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
      <br />
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