import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";

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
    }, []);

    const getData = () => {
        const API = 'https://localhost:8000/api/Shifts'
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const getShiftTypeData = () => {
        const API = 'https://localhost:8000/api/ShiftTypes'
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
        const API = `https://localhost:8000/api/Shifts/${id}`;
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
        const API = `https://localhost:8000/api/Shifts/${Id}`;
        axios.delete(API)
            .then(() => {
                toast.error('Shift is verwijderd');
                getData();
                handleClose();
            })
            .catch((error) => {
                toast.warning(`${error}`);
            })

    }

    const renderShiftType = () => {
        return shiftTypeData.map((item) => (
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
                            <InputLabel>Shift</InputLabel>
                            <Select
                                value={shiftTypeId}
                                onChange={(e) => setShiftTypeId(e.target.value)}
                            >
                                {renderShiftType()}
                            </Select>
                        </FormControl>
                        <TextField
                            style={{ width: '75%' }}
                            type="time"
                            className="form-control"
                            value={starttime}
                            onChange={(e) => setStarttime(e.target.value)}
                            disabled
                        />
                        <TextField
                            style={{ width: '75%' }}
                            type="time"
                            className="form-control"
                            value={endtime}
                            onChange={(e) => setEndtime(e.target.value)}
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
export default DeleteShift;