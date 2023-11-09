import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { TimePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';
import { API_BASE_URL } from "../../config";

function DeleteShift(props) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [Id, editId] = useState('');
    const [starttime, setStarttime] = useState('');
    const [endtime, setEndtime] = useState('');
    const [shiftTypeId, setShiftTypeId] = useState('');
    const [data, setData] = useState([]);
    const [shiftTypeData, setShiftTypeData] = useState([]);

    useEffect(() => {
        getData();
        getShiftTypeData();
    }, [props.dataChanged]);

    const getData = () => {
        const API = `${API_BASE_URL}/Shifts`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const getShiftTypeData = () => {
        const API = `${API_BASE_URL}/ShiftTypes`;
        axios.get(API)
            .then((result) => {
                setShiftTypeData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleDelete = (id) => {
        handleShow();
        const API = `${API_BASE_URL}/Shifts/${id}`;
        axios.get(API)
            .then((result) => {
                setStarttime(result.data.starttime);
                setEndtime(result.data.endtime);
                setShiftTypeId(result.data.shiftTypeId);
                editId(id);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handlePostDelete = () => {
        const API = `${API_BASE_URL}/Shifts/${Id}`;
        axios.delete(API)
            .then(() => {
                toast.error('Shift is verwijderd');
                getData();
                handleClose();
            })
            .catch((error) => {
                toast.warning(`${error}`);
            })
        props.dataChanged(true);
    }

    const renderShiftType = () => {
        return shiftTypeData.map((item) => (
            <MenuItem key={item.id} value={item.id}>
                {item.name}
            </MenuItem>
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
                    <Modal.Title>Shift verwijderen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <h6>Ben je zeker dat je dit shift wilt verwijderen?</h6>
                        <FormControl style={{ width: '75%' }} disabled>
                            <InputLabel>Shift *</InputLabel>
                            <Select
                                required
                                label="Shift"
                                value={shiftTypeId}
                                onChange={(e) => setShiftTypeId(e.target.value)}
                            >
                                {renderShiftType()}
                            </Select>
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <TimePicker slotProps={{ textField: { error: false } }}
                                required
                                label="Starttijd *"
                                value={dayjs(starttime, 'HH:mm:ss').toDate()}
                                onChange={(e) => setStarttime(dayjs(e).format('HH:mm:ss'))}
                                disabled
                            />
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <TimePicker slotProps={{ textField: { error: false } }}
                                required
                                label="Eindtijd *"
                                value={dayjs(endtime, 'HH:mm:ss').toDate()}
                                onChange={(e) => setEndtime(dayjs(e).format('HH:mm:ss'))}
                                disabled
                            />
                        </FormControl>
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
export default DeleteShift;