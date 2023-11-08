import axios from "axios";
import React, { useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import { Button, Stack } from "@mui/material";
import { API_BASE_URL } from "../../config";

function ClearHolidayList(props) {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    useEffect(() => {
    }, []);

    const handlePostClear = () => {
        const API = `${API_BASE_URL}/Holidays`;
        axios.delete(API)
            .then(() => {
                toast.error('Feestdag lijst is verwijderd');
                handleClose();
            })
            .catch((error) => {
                toast.warning(`${error}`);
            })
        props.dataChanged(true);
    }

    return (
        <>
            <Button
                variant="contained"
                color="error"
                onClick={handleShow}
            >
                Lijst verwijderen
            </Button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Feestdag lijst verwijderen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <h6>Ben je zeker dat je heel de feestdag lijst wilt wissen?</h6>
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Stack direction="row" alignItems="center" spacing={2}>
                        <Button variant="contained" color="inherit" onClick={handleClose}>
                            Terug
                        </Button>
                        <Button variant="contained" color="error" onClick={handlePostClear}>
                            Verwijderen
                        </Button>
                    </Stack>
                </Modal.Footer>
            </Modal>
        </>
    );

}
export default ClearHolidayList;