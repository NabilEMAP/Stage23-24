import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack } from "@mui/material";

function GenerateFeestdagen() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [jaar, setJaar] = useState('');

  useEffect(() => {
  }, []);

  const handleCreate = () => {
    const API = `https://localhost:8000/api/Feestdagen?jaar=${jaar}`;
    axios.post(API)
      .then(() => {
        toast.success('Feestdagen zijn gegenereerd');
        clear();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error}`);
        clear();
      })
  }

  const clear = () => {
    setJaar('');
  }

  const renderJaren = () => {
    const jaren = Array.from({ length: 100 }, (_, index) => 2000 + index);
    return (
      <>
        <Select
          value={jaar}
          onChange={(e) => setJaar(e.target.value)}
        >
          {jaren.map((jaar) => (
            <MenuItem value={jaar}>{jaar}</MenuItem>
          ))}
        </Select>

      </>
    );
  };

  return (
    <>
      <Button
        variant="contained"
        color="success"
        onClick={() => handleShow()}
      >
        Genereer Feestdagen
      </Button>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Feestdag genereren</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
            <FormControl style={{ width: '75%' }}>
              <InputLabel>Jaar</InputLabel>
              {renderJaren()}
            </FormControl>
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button variant="contained" color="inherit" onClick={handleClose}>
              Terug
            </Button>
            <Button variant="contained" color="success" onClick={handleCreate}>
              Genereer
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );

}
export default GenerateFeestdagen;