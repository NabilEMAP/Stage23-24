import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControlLabel, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";

function DeleteZorgkundige(props) {
  const [showDelete, setShowDelete] = useState(false);
  const handleCloseDelete = () => setShowDelete(false);
  const handleShowDelete = () => setShowDelete(true);
  const [editID, setEditID] = useState('');
  const [editVoornaam, setEditVoornaam] = useState('');
  const [editAchternaam, setEditAchternaam] = useState('');
  const [editIsVasteNacht, setEditIsVasteNacht] = useState(false);
  const [data, setData] = useState([]);

  useEffect(() => {
    getData();
  }, []);

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

  const handleDelete = (id) => {
    handleShowDelete();
    const API = `https://localhost:8000/api/Zorgkundigen/${id}`;
    axios.get(API)
      .then((result) => {
        setEditVoornaam(result.data.voornaam,);
        setEditAchternaam(result.data.achternaam);
        setEditIsVasteNacht(result.data.isVasteNacht);
        setEditID(id);
      })
      .catch((error) => {
        console.log(error);
      })
  }

  const handlePostDelete = () => {
    const API = `https://localhost:8000/api/Zorgkundigen/${editID}`;
    axios.delete(API)
      .then(() => {
        toast.success('Zorgkundige is verwijderd');
        getData();
        handleCloseDelete();
      })
      .catch((error) => {
        toast.error(`${error}`);
      })

  }

  const handleEditActiveChange = (e) => {
    if (e.target.checked) {
      setEditIsVasteNacht(true);
    }
    else {
      setEditIsVasteNacht(false);
    }
  }

  return (
    <>
      <Button
        variant="contained"
        color="error"
        onClick={() => handleDelete(props.id)}
      >
        <FontAwesomeIcon icon={faTrash} />
      </Button>
      <Modal show={showDelete} onHide={handleCloseDelete}>
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
              type="text"
              className="form-control"
              placeholder="Vul uw voornaam..."
              value={editVoornaam}
              onChange={(e) => setEditVoornaam(e.target.value)}
              disabled
            />
            <TextField
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              placeholder="Vul uw achternaam..."
              value={editAchternaam}
              onChange={(e) => setEditAchternaam(e.target.value)}
              disabled
            />
            <FormControlLabel label="Vaste Nacht" control={
              <Checkbox type="checkbox"
                checked={editIsVasteNacht === true ? true : false}
                value={editIsVasteNacht}
                onChange={(e) => handleEditActiveChange(e)}
                disabled
              />
            } />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button variant="contained" color="inherit" onClick={handleCloseDelete}>
              Terug
            </Button>
            <Button variant="contained" color="error" onClick={handlePostDelete}>
              Verwijderen
            </Button>
          </Stack>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteZorgkundige;
