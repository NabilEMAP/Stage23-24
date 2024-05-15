import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, Stack } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../../config";
import dayjs from "dayjs";

function DeleteTeamplan(props) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [Id, editId] = useState('');
    const [name, setName] = useState('');
    const [planFor, setPlanFor] = useState('');
    const [createdOn, setCreatedOn] = useState('');
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/Teamplans`;
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
        const API = `${API_BASE_URL}/Teamplans/${id}`;
        axios.get(API)
            .then((result) => {
                setName(result.data.name);
                setPlanFor(dayjs(result.data.planFor).format('YYYY-MM'));
                setCreatedOn(result.data.createdOn);
                editId(id);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const handlePostDelete = () => {
        const API = `${API_BASE_URL}/Teamplans/${Id}`;
        axios.delete(API)
            .then(() => {
                toast.error('Teamplan is verwijderd');
                handleClose();
                props.onUpdate();
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
                    <Modal.Title>Teamplan verwijderen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <h6>Ben je zeker dat je deze teamplan wilt verwijderen?</h6>
                        <FormControl style={{ width: '75%' }}>
                            <h4>Naam</h4>
                            <p id="name" value={name}>{name}</p>
                            <h4>Planning voor</h4>
                            <p id="planFor" value={planFor}>{planFor}</p>
                            <h4>Aangemaakt op</h4>
                            <p id="createdOn" value={createdOn}>{createdOn}</p>
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

export default DeleteTeamplan;