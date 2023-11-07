import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";

function EditVacation(props) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [Id, editId] = useState('');
    const [startdate, setStartdate] = useState('');
    const [enddate, setEnddate] = useState('');
    const [nurseId, setNurseId] = useState('');
    const [vacationTypeId, setVacationTypeId] = useState('');
    const [reason, setReason] = useState('');
    const [data, setData] = useState([]);
    const [nurseData, setNurseData] = useState([]);
    const [vacationTypeData, setVacationTypeData] = useState([]);

    useEffect(() => {
        getData();
        getNurseData();
        getVacationTypeData();
    }, []);

    const getData = () => {
        const API = 'https://localhost:8000/api/Vacations/details'
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const getNurseData = () => {
        const API = 'https://localhost:8000/api/Nurses'
        axios.get(API)
            .then((result) => {
                setNurseData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const getVacationTypeData = () => {
        const API = 'https://localhost:8000/api/VacationTypes'
        axios.get(API)
            .then((result) => {
                setVacationTypeData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleEdit = (id) => {
        handleShow();
        const API = `https://localhost:8000/api/Vacations/${id}`;
        axios.get(API)
            .then((result) => {
                setStartdate(result.data.startdate);
                setEnddate(result.data.enddate);
                setNurseId(result.data.nurseId);
                setVacationTypeId(result.data.vacationTypeId);
                setReason(result.data.reason);
                editId(id);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleUpdate = () => {
        const errorMessages = [];

        if (!startdate) errorMessages.push('Startdatum mag niet leeg zijn');
        if (!enddate) errorMessages.push('Einddatum mag niet leeg zijn');
        if (!nurseId) errorMessages.push('Zorgkundige mag niet leeg zijn');
        if (!vacationTypeId) errorMessages.push('Verlof mag niet leeg zijn');

        if (errorMessages.length > 0) {
            const errorMessage = errorMessages.join('\n');
            toast.warning(errorMessage);
            return;
        }

        const API = `https://localhost:8000/api/Vacations/${Id}`;
        const data =
        {
            "id": Id,
            "startdate": startdate,
            "enddate": enddate,
            "nurseId": nurseId,
            "vacationTypeId": vacationTypeId,
            "reason": reason
        }
        axios.put(API, data)
            .then(() => {
                toast.success('Verlof is gewijzigd');
                getData();
                handleClose();
            })
            .catch((error) => {
                if (error.response) {
                    toast.warning('Zie dat de gegevens correct ingevuld zijn');
                } else {
                    toast.warning(`${error.response.data.Message}`);
                }
                console.log(data);
                console.log(JSON.stringify(error));
            })
            props.dataChanged(true);
    }

    const renderNurse = () => {
        return nurseData.map((item) => (
            <MenuItem value={item.id}>{item.firstName + ' ' + item.lastName}</MenuItem>
        ));
    }

    const renderVacationsType = () => {
        return vacationTypeData.map((item) => (
            <MenuItem value={item.id}>{item.name}</MenuItem>
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
                    <Modal.Title>Verlof wijzigen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <FormControl style={{ width: '75%' }}>
                            <InputLabel>Zorgkundige *</InputLabel>
                            <Select
                                required
                                label="Zorgkundige"
                                value={nurseId}
                                onChange={(e) => setNurseId(e.target.value)}
                            >
                                {renderNurse()}
                            </Select>
                        </FormControl>
                        <TextField
                            required
                            label="Startdatum"
                            style={{ width: '75%' }}
                            type="date"
                            className="form-control"
                            value={startdate}
                            onChange={(e) => setStartdate(e.target.value)}
                        />
                        <TextField
                            required
                            label="Einddatum"
                            style={{ width: '75%' }}
                            type="date"
                            className="form-control"
                            value={enddate}
                            onChange={(e) => setEnddate(e.target.value)}
                        />
                        <FormControl style={{ width: '75%' }}>
                            <InputLabel>Verlof *</InputLabel>
                            <Select
                                required
                                label="Verlof"
                                value={vacationTypeId}
                                onChange={(e) => setVacationTypeId(e.target.value)}
                            >
                                {renderVacationsType()}
                            </Select>
                        </FormControl>
                        <TextField
                            label="Reden"
                            style={{ width: '75%' }}
                            type="text"
                            className="form-control"
                            value={reason}
                            multiline={true}
                            minRows={6}
                            onChange={(e) => setReason(e.target.value)}
                        />
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
export default EditVacation;