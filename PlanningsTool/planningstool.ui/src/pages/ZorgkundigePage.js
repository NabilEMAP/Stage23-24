import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Modal from 'react-bootstrap/Modal';
import { toast } from 'react-toastify';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Button, Checkbox, FormControlLabel, Stack, TextField } from "@mui/material";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash } from "@fortawesome/free-solid-svg-icons";
import { MyTC, MyTR } from "../components/MyTable";
import AddZorgkundige from "../components/zorgkundigen/AddZorgkundige";
import EditZorgkundige from "../components/zorgkundigen/EditZorgkundige";

function ZorgkundigePage() {
    const [showDelete, setShowDelete] = useState(false);
    const handleCloseDelete = () => setShowDelete(false);
    const handleShowDelete = () => setShowDelete(true);

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

    const handleEditActiveChange = (e) => {
        if (e.target.checked) {
            setEditIsVasteNacht(true);
        }
        else {
            setEditIsVasteNacht(false);
        }
    }

    return (
        <Fragment>
            <AddZorgkundige />

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
                    <Stack direction="row" alignItems="center" spacing={2}>
                        <Button variant="contained" color="inherit" onClick={handleCloseDelete}>
                            Terug
                        </Button>
                        <Button variant="contained" color="error" onClick={handlePostDelete}>
                            Verwijderen
                        </Button>
                    </Stack>
                </Modal.Footer>
            </Modal>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 700 }} aria-label="customized table">
                    <TableHead>
                        <TableRow>
                            <MyTC></MyTC>
                            <MyTC>Voornaam</MyTC>
                            <MyTC>Achternaam</MyTC>
                            <MyTC>Vaste Nacht?</MyTC>
                            <MyTC>Veranderingen</MyTC>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {data && data.length > 0 ? data.map((item, index) => {
                            return (
                                <MyTR key={index}>
                                    <MyTC>{item.id}</MyTC>
                                    <MyTC>{item.voornaam}</MyTC>
                                    <MyTC>{item.achternaam}</MyTC>
                                    <MyTC>{(item.isVasteNacht) ? "Ja" : "Nee"}</MyTC>
                                    <MyTC>
                                        <EditZorgkundige />
                                        <Button variant="contained" color="error" onClick={() => handleDelete(item.id)}><FontAwesomeIcon icon={faTrash} /></Button>
                                    </MyTC>
                                </MyTR>
                            )
                        }) : 'No data found'}
                    </TableBody>
                </Table>
            </TableContainer>
        </Fragment>
    );
}

export default ZorgkundigePage;