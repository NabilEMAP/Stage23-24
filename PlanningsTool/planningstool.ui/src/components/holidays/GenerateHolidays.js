import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack } from "@mui/material";

function GenerateHolidays() {
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  const [year, setYear] = useState('');

  useEffect(() => {
  }, []);

  const handleCreate = () => {
    const API = `https://localhost:8000/api/Holidays?year=${year}`;
    axios.post(API)
      .then(() => {
        toast.success('Feestdagen zijn gegenereerd');
        clear();
        handleClose();
      })
      .catch((error) => {
        toast.warning(`${error.response.data}`);
        clear();
      })
  }

  const clear = () => {
    setYear('');
  }

  const renderYears = () => {
    const years = Array.from({ length: 100 }, (_, index) => 2000 + index);
    return (
      <>
        <Select
          value={year}
          onChange={(e) => setYear(e.target.value)}
        >
          {years.map((year) => (
            <MenuItem value={year}>{year}</MenuItem>
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
              {renderYears()}
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
export default GenerateHolidays;