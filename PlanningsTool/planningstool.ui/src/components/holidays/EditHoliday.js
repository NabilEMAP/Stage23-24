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

function EditHoliday(props) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [Id, editId] = useState('');
    const [name, setName] = useState('');
    const [date, setDate] = useState('');
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/Holidays`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleEdit = (id) => {
        handleShow();
        const API = `${API_BASE_URL}/Holidays/${id}`;
        axios.get(API)
            .then((result) => {
                setName(result.data.name);
                setDate(result.data.date);
                editId(id);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleUpdate = () => {
        const errorMessages = [];

        if (!name) errorMessages.push('Naam mag niet leeg zijn');
        if (!date) errorMessages.push('Datum mag niet leeg zijn');


        if (errorMessages.length > 0) {
            const errorMessage = errorMessages.join('\n');
            toast.warning(errorMessage);
            return;
        }

        const API = `${API_BASE_URL}/Holidays/${Id}`;
        const data =
        {
            "id": Id,
            "name": name,
            "date": date,
        }
        axios.put(API, data)
            .then(() => {
                toast.success('Feestdag is gewijzigd');
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
                console.log(JSON.stringify(error));
            })
        console.log(data);
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
                    <Modal.Title>Feestdag wijzigen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="top-center"
                        alignItems="center"
                        spacing={4}
                        style={{ height: '250px' }}
                    >
                        <TextField style={{ width: '75%' }}
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
                                id="txtInputDate"
                                label="Datum *"
                                value={dayjs(date)}
                                onChange={(e) => setDate(dayjs(e).format('YYYY-MM-DD'))}
                            />
                        </FormControl>
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Stack direction="row" alignItems="center" spacing={2}>
                        <Button id="goBack" variant="contained" color="inherit" onClick={handleClose}>
                            Terug
                        </Button>
                        <Button id="submitHolidayForm" variant="contained" color="primary" onClick={handleUpdate}>
                            Wijzigen
                        </Button>
                    </Stack>
                </Modal.Footer>
            </Modal>
        </>
    );

}
export default EditHoliday;