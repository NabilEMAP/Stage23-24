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
    const [showAdd, setShowAdd] = useState(false);
    const handleCloseAdd = () => setShowAdd(false);
    const handleShowAdd = () => setShowAdd(true);

    const [showEdit, setShowEdit] = useState(false);
    const handleCloseEdit = () => setShowEdit(false);
    const handleShowEdit = () => setShowEdit(true);

    const [showDelete, setShowDelete] = useState(false);
    const handleCloseDelete = () => setShowDelete(false);
    const handleShowDelete = () => setShowDelete(true);

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

    const handleCreate = () => {
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
                toast.success('Zorgkundige is toegevoegd');
                clear();
                handleCloseAdd();
            })
            .catch((error) => {
                toast.error(error);
            })
    }

    const handleEdit = (id) => {
        handleShowEdit();
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
                handleCloseEdit();
            })
            .catch((error) => {
                toast.error(`${error}`);
            })
    }

    const handleDelete = (id) => {
        handleShowDelete();
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

    const handlePostDelete = () => {
        const API = `https://localhost:8000/api/Zorgkundigen/${editID}`;
        axios.delete(API)
            .then(() => {
                toast.success('Zorgkundige is verwijderd');
                getData();
                handleCloseDelete();
            })
            .catch((error) => {
                toast.error(`${error}`);
            })

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

    const clear = () => {
        setVoornaam('');
        setAchternaam('');
        setIsVasteNacht(false);
        setEditVoornaam('');
        setEditAchternaam('');
        setEditIsVasteNacht(false);
    }

    return (
        <Fragment>
            <MyToastify />
            <Button
                style={{float: 'right'}}
                className="btn btn-success"
                onClick={() => handleShowAdd()}
            >
                Zorgkundige toevoegen
            </Button>
            <br />
            <Modal show={showAdd} onHide={handleCloseAdd}>
                <Modal.Header closeButton>
                    <Modal.Title>Zorgkundige toevoegen</Modal.Title>
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
                            value={voornaam}
                            onChange={(e) => setVoornaam(e.target.value)}
                        />
                        <TextField
                            style={{ width: '75%' }}
                            type="text"
                            className="form-control"
                            placeholder="Vul uw achternaam..."
                            value={achternaam}
                            onChange={(e) => setAchternaam(e.target.value)}
                        />
                        <FormControlLabel label="Vaste Nacht" control={
                            <Checkbox
                                type="checkbox"
                                checked={isVasteNacht === true ? true : false}
                                value={isVasteNacht}
                                onChange={(e) => handleActiveChange(e)}
                            />
                        } />
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseAdd}>
                        Terug
                    </Button>
                    <Button variant="success" onClick={handleCreate}>
                        Toevoegen
                    </Button>
                </Modal.Footer>
            </Modal>
            <Modal show={showEdit} onHide={handleCloseEdit}>
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
                                onChange={(e) => handleEditActiveChange(e)}
                            />
                        } />
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseEdit}>
                        Terug
                    </Button>
                    <Button variant="primary" onClick={handleUpdate}>
                        Wijzigen
                    </Button>
                </Modal.Footer>
            </Modal>
            <Modal show={showDelete} onHide={handleCloseDelete}>
                <Modal.Header closeButton>
                    <Modal.Title>Zorgkundige verwijderen</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Stack
                        direction="column"
                        justifyContent="center"
                        alignItems="center"
                        spacing={4}
                    >
                        <h6>Ben je zeker dat je deze zorgkundige wilt verwijderen?</h6>
                        <TextField
                            style={{ width: '75%' }}
                            type="text"
                            className="form-control"
                            placeholder="Vul uw voornaam..."
                            value={editVoornaam}
                            onChange={(e) => setEditVoornaam(e.target.value)}
                            disabled
                        />
                        <TextField
                            style={{ width: '75%' }}
                            type="text"
                            className="form-control"
                            placeholder="Vul uw achternaam..."
                            value={editAchternaam}
                            onChange={(e) => setEditAchternaam(e.target.value)}
                            disabled
                        />
                        <FormControlLabel label="Vaste Nacht" control={
                            <Checkbox type="checkbox"
                                checked={editIsVasteNacht === true ? true : false}
                                value={editIsVasteNacht}
                                onChange={(e) => handleEditActiveChange(e)}
                                disabled
                            />
                        } />
                    </Stack>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseDelete}>
                        Terug
                    </Button>
                    <Button variant="danger" onClick={handlePostDelete}>
                        Verwijderen
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