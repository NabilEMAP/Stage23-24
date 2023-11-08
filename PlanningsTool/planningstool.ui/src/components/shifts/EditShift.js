import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, IconButton } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen } from "@fortawesome/free-solid-svg-icons";
import { TimePicker } from "@mui/x-date-pickers";
import dayjs from 'dayjs';

function EditShift(props) {
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

    const handleEdit = (id) => {
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
        console.log(data);
    }

    const handleUpdate = () => {
        const API = `https://localhost:8000/api/Shifts/${Id}`;
        const data =
        {
            "id": Id,
            "starttime": starttime,
            "endtime": endtime,
            "shiftTypeId": shiftTypeId
        }
        axios.put(API, data)
            .then(() => {
                toast.success('Shift is gewijzigd');
                getData();
                handleClose();
            })
            .catch((error) => {
                toast.warning(`${error}`);
                console.log(error);
            })
        console.log(data);
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
                color="primary"
                onClick={() => handleEdit(props.id)}
            >
                <FontAwesomeIcon icon={faPen} />
            </IconButton>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Shift wijzigen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <FormControl style={{ width: '75%' }}>
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
                            <TimePicker
                                slotProps={{ textField: { error: false } }}
                                required
                                label="Starttijd *"
                                value={starttime}
                                onChange={(e) => setStarttime(dayjs(e).format('HH:mm:ss'))}
                            />
                        </FormControl>
                        <FormControl style={{ width: '75%' }}>
                            <TimePicker slotProps={{ textField: { error: false } }}
                                required
                                label="Eindtijd *"
                                value={endtime}
                                onChange={(e) => setEndtime(dayjs(e).format('HH:mm:ss'))}
                            />
                        </FormControl>
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
export default EditShift;