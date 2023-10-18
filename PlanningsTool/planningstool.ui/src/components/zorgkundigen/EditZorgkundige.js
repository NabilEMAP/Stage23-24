import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Checkbox, FormControlLabel, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";

function EditZorgkundige(props) {
  const [showEdit, setShowEdit] = useState(false);
  const handleCloseEdit = () => setShowEdit(false);
  const handleShowEdit = () => setShowEdit(true);
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

  const handleEdit = (id) => {
    handleShowEdit();
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

  const handleUpdate = () => {
    const API = `https://localhost:8000/api/Zorgkundigen/${editID}`;
    const data =
    {
      "id": editID,
      "voornaam": editVoornaam,
      "achternaam": editAchternaam,
      "isVasteNacht": editIsVasteNacht
    }
    axios.put(API, data)
      .then((result) => {
        toast.success('Zorgkundige is gewijzigd');
        getData();
        handleCloseEdit();
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
        color="primary"
        onClick={() => handleEdit(props.id)}
      >
        <FontAwesomeIcon icon={faPen} />
      </Button>
      <Modal show={showEdit} onHide={handleCloseEdit}>
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
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              placeholder="Vul uw voornaam..."
              value={editVoornaam}
              onChange={(e) => setEditVoornaam(e.target.value)}
            />
            <TextField
              style={{ width: '75%' }}
              type="text"
              className="form-control"
              placeholder="Vul uw achternaam..."
              value={editAchternaam}
              onChange={(e) => setEditAchternaam(e.target.value)}
            />
            <FormControlLabel label="Vaste Nacht" control={
              <Checkbox type="checkbox"
                checked={editIsVasteNacht === true ? true : false}
                value={editIsVasteNacht}
                onChange={(e) => handleEditActiveChange(e)}
              />
            } />
          </Stack>
        </Modal.Body>
        <Modal.Footer>
          <Stack direction="row" alignItems="center" spacing={2}>
            <Button variant="contained" color="inherit" onClick={handleCloseEdit}>
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

export default EditZorgkundige;