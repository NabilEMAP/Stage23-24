import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { DatePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

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
        const API = `${API_BASE_URL}/VacationTypes`;
        axios.get(API)
            .then((result) => {
                setVacationTypeData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const handleEdit = (id) => {
        handleShow();
        const API = `${API_BASE_URL}/Vacations/${id}`;
        axios.get(API)
            .then((result) => {
                setStartdate(result.data.startdate);
                setEnddate(result.data.enddate);
                setTeamId(result.data.nurse.teamId);
                setNurseId(result.data.nurseId);
                setVacationTypeId(result.data.vacationTypeId);
                setReason(result.data.reason);
                editId(id);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    const handleUpdate = () => {
        const errorMessages = [];

        if (!startdate) errorMessages.push('Startdatum mag niet leeg zijn');
        if (!enddate) errorMessages.push('Einddatum mag niet leeg zijn');
        if (!teamId) errorMessages.push('Team mag niet leeg zijn');
        if (!nurseId) errorMessages.push('Zorgkundige mag niet leeg zijn');
        if (!vacationTypeId) errorMessages.push('Verlof mag niet leeg zijn');

        if (errorMessages.length > 0) {
            const errorMessage = errorMessages.join('\n');
            toast.warning(errorMessage);
            return;
        }

        const API = `${API_BASE_URL}/Vacations/${Id}`;
        const data =
        {
            "id": Id,
            "startdate": startdate,
            "enddate": enddate,
            "teamId": teamId,
            "nurseId": nurseId,
            "vacationTypeId": vacationTypeId,
            "reason": reason
        }
        axios.put(API, data)
            .then(() => {
                toast.success('Verlof is gewijzigd');
                handleClose();
                props.onUpdate();
                if (props.onEditComplete) {
                    props.onEditComplete();
                }
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    toast.warning('Zie dat de gegevens correct ingevuld zijn');
                } else {
                    toast.warning(`${error.response.data.Message}`);
                }
            })
    }

    const renderTeam = () => {
        return teamData.map((item) => (
            <MenuItem key={item.id} value={item.id}>
                {item.teamName}
            </MenuItem>
        ));
    }

    const renderNurse = () => {
        const filteredNurses = nurseData.filter(nurse => nurse.teamId === teamId);
        return filteredNurses.map((item) => (
            <MenuItem key={item.id} value={item.id}>
                {item.firstName + ' ' + item.lastName}
            </MenuItem>
        ));
    }

    const renderVacationsType = () => {
        return vacationTypeData.map((item) => (
            <MenuItem key={item.id} value={item.id}>
                {item.name}
            </MenuItem>
        ));
    }

    const handleTeamChange = (e) => {
        const selectedTeamId = e.target.value;
        setTeamId(selectedTeamId);
        setNurseId('');
        getNurseData(selectedTeamId);
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
                            <InputLabel>Teams *</InputLabel>
                            <Select
                                required
                                id="selectTeam"
                                label="Team"
                                value={teamId}
                                onChange={handleTeamChange}
                            >
                                {renderTeam()}
                            </Select>
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <InputLabel>Zorgkundige *</InputLabel>
                            <Select
                                required
                                id="selectNurse"
                                label="Zorgkundige"
                                value={nurseId}
                                onChange={(e) => setNurseId(e.target.value)}
                            >
                                {renderNurse()}
                            </Select>
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <DatePicker slotProps={{ textField: { error: false } }}
                                required
                                id="txtInputStartDate"
                                label="Startdatum *"
                                value={dayjs(startdate)}
                                onChange={(e) => setStartdate(dayjs(e).format('YYYY-MM-DD'))}
                            />
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <DatePicker slotProps={{ textField: { error: false } }}
                                required
                                id="txtInputEndDate"
                                label="Einddatum *"
                                value={dayjs(enddate)}
                                onChange={(e) => setEnddate(dayjs(e).format('YYYY-MM-DD'))}
                            />
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <InputLabel>Verlof *</InputLabel>
                            <Select
                                required
                                id="selectVacation"
                                label="Verlof"
                                value={vacationTypeId}
                                onChange={(e) => setVacationTypeId(e.target.value)}
                            >
                                {renderVacationsType()}
                            </Select>
                        </FormControl>
                        <TextField
                            id="txtInputReason"
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
                        <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
                            Terug
                        </Button>
                        <Button id="submitVacationForm" variant="contained" color="primary" onClick={handleUpdate}>
                            Wijzigen
                        </Button>
                    </Stack>
                </Modal.Footer>
            </Modal>
        </>
    );

}
export default EditVacation;