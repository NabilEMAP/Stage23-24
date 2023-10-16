import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { toast } from 'react-toastify';

import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import MyToastify from "./MyToastify";
import { Checkbox, FormControlLabel, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPen, faTrash } from "@fortawesome/free-solid-svg-icons";

const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
        fontSize: 16,
    },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
    },
    // hide last border
    '&:last-child td, &:last-child th': {
        border: 0,
    },
}));

function ZorgkundigePagina() {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [voornaam, setVoornaam] = useState('');
    const [achternaam, setAchternaam] = useState('');
    const [isVasteNacht, setIsVasteNacht] = useState(false);

    const [editID, setEditID] = useState('');
    const [editVoornaam, setEditVoornaam] = useState('');
    const [editAchternaam, setEditAchternaam] = useState('');
    const [editIsVasteNacht, setEditIsVasteNacht] = useState(false);

    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = 'https://localhost:8000/api/Zorgkundigen/details'
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleSave = () => {
        const API = 'https://localhost:8000/api/Zorgkundigen';
        const data =
        {
            "voornaam": voornaam,
            "achternaam": achternaam,
            "isVasteNacht": isVasteNacht
        }
        axios.post(API, data)
            .then((result) => {
                getData();
                clear();
                toast.success('Zorgkundige is toegevoegd');
            })
            .catch((error) => {
                toast.error(error);
            })
    }

    const clear = () => {
        setVoornaam('');
        setAchternaam('');
        setIsVasteNacht(false);
        setEditVoornaam('');
        setEditAchternaam('');
        setEditIsVasteNacht(false);
    }

    const handleActiveChange = (e) => {
        if (e.target.checked) {
            setIsVasteNacht(true);
        }
        else {
            setIsVasteNacht(false);
        }
    }

    const handleEditActiveChange = (e) => {
        if (e.target.checked) {
            setEditIsVasteNacht(true);
        }
        else {
            setEditIsVasteNacht(false);
        }
    }

    const handleEdit = (id) => {
        handleShow();
        const API = `https://localhost:8000/api/Zorgkundigen/${id}`;
        axios.get(API)
            .then((result) => {
                setEditVoornaam(result.data.voornaam,);
                setEditAchternaam(result.data.achternaam);
                setEditIsVasteNacht(result.data.isVasteNacht);
                setEditID(id);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const handleDelete = (id) => {
        const API = `https://localhost:8000/api/Zorgkundigen/${id}`;
        const message = "Ben je zeker dat je deze zorgkundige wilt verwijderen?";
        if (window.confirm(message) === true) {
            axios.delete(API)
                .then(() => {
                    toast.success('Zorgkundige is verwijderd');
                    getData();

                })
                .catch((error) => {
                    toast.error(error);
                })
        }
    }

    const handleUpdate = () => {
        const API = `https://localhost:8000/api/Zorgkundigen/${editID}`;
        const data =
        {
            "id": editID,
            "voornaam": editVoornaam,
            "achternaam": editAchternaam,
            "isVasteNacht": editIsVasteNacht
        }
        axios.put(API, data)
            .then((result) => {
                toast.success('Zorgkundige is gewijzigd');
                getData();
                handleClose();
            })
            .catch((error) => {
                console.log(error);
            })
    }

    return (
        <Fragment>
            <MyToastify />
            <Container>
                <Row>
                    <Col>
                        <TextField
                            type="text"
                            className="form-control"
                            placeholder="Voornaam..."
                            value={voornaam}
                            onChange={(e) => setVoornaam(e.target.value)}
                        />
                    </Col>
                    <Col>
                        <TextField
                            type="text"
                            className="form-control"
                            placeholder="Achternaam..."
                            value={achternaam}
                            onChange={(e) => setAchternaam(e.target.value)}
                        />
                    </Col>
                    <Col>
                        <FormControlLabel label="Vaste Nacht" control={
                            <Checkbox
                                type="checkbox"
                                checked={isVasteNacht === true ? true : false}
                                value={isVasteNacht}
                                onChange={(e) => handleActiveChange(e)}
                            />
                        } />
                    </Col>
                    <Col>
                        <Button
                            className="btn btn-primary"
                            onClick={() => handleSave()}
                        >
                            Submit
                        </Button>
                    </Col>
                </Row>
            </Container>
            <br />
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Zorgkundige wijzigen</Modal.Title>
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
                            type="text"
                            className="form-control"
                            placeholder="Vul uw voornaam..."
                            value={editVoornaam}
                            onChange={(e) => setEditVoornaam(e.target.value)}
                        />
                        <TextField
                            style={{ width: '75%' }}
                            type="text"
                            className="form-control"
                            placeholder="Vul uw achternaam..."
                            value={editAchternaam}
                            onChange={(e) => setEditAchternaam(e.target.value)}
                        />
                        <FormControlLabel label="Vaste Nacht" control={
                            <Checkbox type="checkbox"
                                checked={editIsVasteNacht === true ? true : false}
                                value={editIsVasteNacht}
                                onChange={(e) => handleEditActiveChange(e)} />
                        } />
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Terug
                    </Button>
                    <Button variant="primary" onClick={handleUpdate}>
                        Wijzig verandering
                    </Button>
                </Modal.Footer>
            </Modal>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 700 }} aria-label="customized table">
                    <TableHead>
                        <TableRow>
                            <StyledTableCell></StyledTableCell>
                            <StyledTableCell>Voornaam</StyledTableCell>
                            <StyledTableCell>Achternaam</StyledTableCell>
                            <StyledTableCell>Vaste Nacht?</StyledTableCell>
                            <StyledTableCell>Veranderingen</StyledTableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {
                            data && data.length > 0 ?
                                data.map((item, index) => {
                                    return (
                                        <StyledTableRow key={index}>
                                            <StyledTableCell>{item.id}</StyledTableCell>
                                            <StyledTableCell>{item.voornaam}</StyledTableCell>
                                            <StyledTableCell>{item.achternaam}</StyledTableCell>
                                            <StyledTableCell>{(item.isVasteNacht) ? "Ja" : "Nee"}</StyledTableCell>
                                            <StyledTableCell>
                                                <Button className="btn btn-primary" onClick={() => handleEdit(item.id)}><FontAwesomeIcon icon={faPen} /></Button>
                                                <Button className="btn btn-danger" onClick={() => handleDelete(item.id)}><FontAwesomeIcon icon={faTrash} /></Button>
                                            </StyledTableCell>
                                        </StyledTableRow>
                                    )
                                }) : 'No data found'}
                    </TableBody>
                </Table>
            </TableContainer>
        </Fragment>
    );
}

export default ZorgkundigePagina;