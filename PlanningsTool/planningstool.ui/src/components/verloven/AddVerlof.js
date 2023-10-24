import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";

function AddVerlof() {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [startdatum, setStartdatum] = useState('');
    const [einddatum, setEinddatum] = useState('');
    const [zorgkundigeId, setZorgkundigeId] = useState('');
    const [verlofTypeId, setVerlofTypeId] = useState('');
    const [reden, setReden] = useState('');
    const [data, setData] = useState([]);
    const [zorgkundigeData, setZorgkundigeData] = useState([]);
    const [verlofTypeData, setVerlofTypeData] = useState([]);

    useEffect(() => {
        getData();
        getZorgkundigeData();
        getVerlofTypeData();
    }, []);

    const getData = () => {
        const API = 'https://localhost:8000/api/Verloven/details'
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const getZorgkundigeData = () => {
        const API = 'https://localhost:8000/api/Zorgkundigen/details'
        axios.get(API)
            .then((result) => {
                setZorgkundigeData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const getVerlofTypeData = () => {
        const API = 'https://localhost:8000/api/VerlofTypes'
        axios.get(API)
            .then((result) => {
                setVerlofTypeData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleCreate = () => {
        const API = 'https://localhost:8000/api/Verloven';
        const data =
        {
            "startdatum": startdatum,
            "einddatum": einddatum,
            "zorgkundigeId": zorgkundigeId,
            "verlofTypeId": verlofTypeId,
            "reden": reden
        }
        axios.post(API, data)
            .then(() => {
                getData();
                toast.success('Verlof is toegevoegd');
                clear();
                handleClose();
            })
            .catch((error) => {
                toast.error(error);
            })
    }

    const clear = () => {
        setStartdatum('');
        setEinddatum('');
        setZorgkundigeId('');
        setVerlofTypeId('');
        setReden('');
    }

    const renderZorgkundige = () => {
        return zorgkundigeData.map((item) => (
            <MenuItem value={item.id}>{item.voornaam + ' ' + item.achternaam}</MenuItem>
        ));
    }

    const renderVerlofType = () => {
        return verlofTypeData.map((item) => (
            <MenuItem value={item.id}>{item.verlof}</MenuItem>
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
            Verlof toevoegen
          </Button>
          <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Verlof toevoegen</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Stack
                direction="column"
                justifyContent="center"
                alignItems="center"
                spacing={4}
              >
                <FormControl style={{ width: '75%' }}>
                  <InputLabel>Zorgkundige</InputLabel>
                  <Select
                    value={zorgkundigeId}
                    onChange={(e) => setZorgkundigeId(e.target.value)}
                  >
                    {renderZorgkundige()}
                  </Select>
                </FormControl>
                <TextField
                  style={{ width: '75%' }}
                  type="date"
                  className="form-control"
                  value={startdatum}
                  onChange={(e) => setStartdatum(e.target.value)}
                />
                <TextField
                  style={{ width: '75%' }}
                  type="date"
                  className="form-control"
                  value={einddatum}
                  onChange={(e) => setEinddatum(e.target.value)}
                />
                <FormControl style={{ width: '75%' }}>
                  <InputLabel>Verlof</InputLabel>
                  <Select
                    value={verlofTypeId}
                    onChange={(e) => setVerlofTypeId(e.target.value)}
                  >
                    {renderVerlofType()}
                  </Select>
                </FormControl>
                <TextField
                  style={{ width: '75%' }}
                  type="date"
                  className="form-control"
                  placeholder="Reden"
                  value={reden}
                  multiline={true}
                  minRows={6}
                  onChange={(e) => setReden(e.target.value)}
                />
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
export default AddVerlof;