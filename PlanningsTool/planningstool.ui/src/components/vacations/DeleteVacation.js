import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, Stack, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

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
    const [teamId, setTeamId] = useState('');
    const [teamData, setTeamData] = useState([]);

    useEffect(() => {
        getData();
        getTeamData();
        getNurseData();
        getVacationTypeData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/Vacations/details`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const getTeamData = () => {
        const API = `${API_BASE_URL}/Teams`;
        axios.get(API)
            .then((result) => {
                setTeamData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const getNurseData = (teamId) => {
        const API = `${API_BASE_URL}/Nurses?teamId=${teamId}`;
        axios.get(API)
            .then((result) => {
                setNurseData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const getVacationTypeData = () => {
        const API = `${API_BASE_URL}/VacationTypes`
        axios.get(API)
            .then((result) => {
                setVacationTypeData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const handleDelete = (id) => {
        handleShow();
        const API = `${API_BASE_URL}/Vacations/${id}`;
        axios.get(API)
            .then((result) => {
                setStartdate(dayjs(result.data.startdate).format('DD/MM/YYYY'));
                setEnddate(dayjs(result.data.enddate).format('DD/MM/YYYY'));
                const team = teamData.find((item) => item.id === result.data.nurse.teamId);
                setTeamId(team ? team.teamName : '');
                const nurse = nurseData.find((item) => item.id === result.data.nurseId);
                setNurseId(nurse ? nurse.firstName + " " + nurse.lastName : '');
                const vacationType = vacationTypeData.find((item) => item.id === result.data.vacationTypeId);
                setVacationTypeId(vacationType ? vacationType.name : '');
                setReason(result.data.reason);
                editId(id);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const handlePostDelete = () => {
        const API = `${API_BASE_URL}/Vacations/${Id}`;
        axios.delete(API)
            .then(() => {
                toast.error('Verlof is verwijderd');
                handleClose();
                props.onUpdate();
                if (props.onDeleteComplete) {
                    props.onDeleteComplete();
                }
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
                        <FormControl style={{ width: '75%' }}>
                            <h4>Team</h4>
                            <p id="team" value={teamId}>{teamId}</p>
                            <h4>Zorgkundige</h4>
                            <p id="nurse" value={nurseId}>{nurseId}</p>
                            <h4>Startdatum</h4>
                            <p id="startdate" value={startdate}>{startdate}</p>
                            <h4>Einddatum</h4>
                            <p id="enddate" value={enddate}>{enddate}</p>
                            <h4>Verlof</h4>
                            <p id="vacationType" value={vacationTypeId}>{vacationTypeId}</p>
                            <h4>Reden</h4>
                            <p id="reason" value={reason}>{reason}</p>
                        </FormControl>
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Stack direction="row" alignItems="center" spacing={2}>
                        <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
                            Terug
                        </Button>
                        <Button id="submitVacationForm" variant="contained" color="error" onClick={handlePostDelete}>
                            Verwijderen
                        </Button>
                    </Stack>
                </Modal.Footer>
            </Modal>
        </>
    );

}
export default DeleteVacation;