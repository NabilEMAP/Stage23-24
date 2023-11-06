import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";

function DeleteVacation(props) {
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

    const handleDelete = (id) => {
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

    const handlePostDelete = () => {
        const API = `https://localhost:8000/api/Vacations/${Id}`;
        axios.delete(API)
            .then(() => {
                toast.error('Verlof is verwijderd');
                getData();
                handleClose();
            })
            .catch((error) => {
                toast.warning(`${error}`);
            })

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
                color="error"
                onClick={() => handleDelete(props.id)}
            >
                <FontAwesomeIcon icon={faTrash} />
            </IconButton>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Verlof verwijderen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <h6>Ben je zeker dat je dit verlof wilt verwijderen?</h6>
                        <FormControl style={{ width: '75%' }} disabled>
                            <InputLabel>Zorgkundige</InputLabel>
                            <Select
                                value={nurseId}
                                onChange={(e) => setNurseId(e.target.value)}
                            >
                                {renderNurse()}
                            </Select>
                        </FormControl>
                        <TextField
                            style={{ width: '75%' }}
                            type="date"
                            className="form-control"
                            value={startdate}
                            onChange={(e) => setStartdate(e.target.value)}
                            disabled
                        />
                        <TextField
                            style={{ width: '75%' }}
                            type="date"
                            className="form-control"
                            value={enddate}
                            onChange={(e) => setEnddate(e.target.value)}
                            disabled
                        />
                        <FormControl style={{ width: '75%' }} disabled>
                            <InputLabel>Verlof</InputLabel>
                            <Select
                                value={vacationTypeId}
                                onChange={(e) => setVacationTypeId(e.target.value)}
                            >
                                {renderVacationsType()}
                            </Select>
                        </FormControl>
                        <TextField
                            style={{ width: '75%' }}
                            type="date"
                            className="form-control"
                            placeholder="Reden"
                            value={reason}
                            multiline={true}
                            minRows={6}
                            onChange={(e) => setReason(e.target.value)}
                            disabled
                        />
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Stack direction="row" alignItems="center" spacing={2}>
                        <Button variant="contained" color="inherit" onClick={handleClose}>
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
export default DeleteVacation;