import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { API_BASE_URL } from "../../config";
import dayjs from 'dayjs';

function AddTeamplan(props) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [name, setName] = useState('');
    const [planFor, setPlanFor] = useState('');
    const [teamId, setTeamId] = useState('');
    const [teamData, setTeamData] = useState([]);
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
        getTeamData();
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

    const handleCreate = () => {
        const errorMessages = [];

        if (!name) errorMessages.push('Naam mag niet leeg zijn');
        if (!planFor) errorMessages.push('Plan datum mag niet leeg zijn');
        if (!teamId) errorMessages.push('Team mag niet leeg zijn');

        if (errorMessages.length > 0) {
            const errorMessage = errorMessages.join('\n');
            toast.warning(errorMessage);
            return;
        }

        const API = `${API_BASE_URL}/Teamplans`;
        const data = {
            "name": name,
            "planFor": dayjs(planFor).format('YYYY-MM-01'),
            "createdOn": dayjs(),
            "teamId": teamId,
        }
        axios.post(API, data)
            .then(() => {
                toast.success('Teamplan is toegevoegd');
                clear();
                handleClose();
                props.onUpdate();
            })
            .catch((error) => {
                if (error.response.status === 400) {
                    toast.warning('Zie dat de gegevens correct ingevuld zijn');
                } else {
                    toast.warning(`${error.response.data.Message}`);
                }
                clear();
            })
    }

    const clear = () => {
        setName('');
        setTeamId('');
    }

    const renderTeams = () => {
        return teamData.map((item) => (
            <MenuItem key={item.id} value={item.id}>
                {item.teamName}
            </MenuItem>
        ));
    }

    return (
        <>
            <Button
                id="createTeamplan"
                variant="contained"
                style={{ float: 'right' }}
                color="success"
                onClick={() => handleShow()}
            >
                Teamplan toevoegen
            </Button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Teamplan toevoegen</Modal.Title>
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
                        <FormControl style={{ width: '75%' }}>
                            <DatePicker slotProps={{ textField: { error: false } }}
                                required
                                id="txtInputPlanFor"
                                label="Plan voor *"
                                views={['month', 'year']}
                                value={planFor}
                                onChange={(e) => setPlanFor(dayjs(e))}
                            />
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <InputLabel>Team *</InputLabel>
                            <Select
                                required
                                id="selectTeam"
                                label="Team"
                                value={teamId}
                                onChange={(e) => setTeamId(e.target.value)}
                            >
                                {renderTeams()}
                            </Select>
                        </FormControl>
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Stack direction="row" alignItems="center" spacing={2}>
                        <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
                            Terug
                        </Button>
                        <Button id="submitTeamForm" variant="contained" color="success" onClick={handleCreate}>
                            Toevoegen
                        </Button>
                    </Stack>
                </Modal.Footer>
            </Modal>
        </>
    );
}

export default AddTeamplan;