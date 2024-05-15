import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, IconButton, Stack, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../../config";
import dayjs from 'dayjs';

function EditTeamplan(props) {
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

    const handleEdit = (id) => {
        handleShow();
        const API = `${API_BASE_URL}/Teamplans/${id}`;
        axios.get(API)
            .then((result) => {
                setName(result.data.name);
                setPlanFor(result.data.planFor);
                setCreatedOn(result.data.createdOn);
                editId(id);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const handleUpdate = () => {
        const errorMessages = [];

        if (!name) errorMessages.push('Naam mag niet leeg zijn');
        if (!planFor) errorMessages.push('Plan datum mag niet leeg zijn');

        if (errorMessages.length > 0) {
            const errorMessage = errorMessages.join('\n');
            toast.warning(errorMessage);
            return;
        }

        const API = `${API_BASE_URL}/Teamplans/${Id}`;
        const data =
        {
            "id": Id,
            "name": name,
            "planFor": planFor,
            "createdOn": createdOn,
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
                    <Modal.Title>Teamplan wijzigen</Modal.Title>
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
                            id="txtInputName"
                            label="Naam"
                            type="text"
                            className="form-control"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                        />
                        {/*
                        <FormControl style={{ width: '75%' }}>
                            <DatePicker slotProps={{ textField: { error: false } }}
                                required
                                id="txtInputPlanFor"
                                label="Plan voor *"
                                views={['month', 'year']}
                                value={dayjs(planFor).format('YYYY-MM')}
                                onChange={(e) => setPlanFor(dayjs(e))}
                            />
                        </FormControl>
                        */}
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

export default EditTeamplan;