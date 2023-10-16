import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function ZorgkundigeCrud() {
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
                setData(result.data)
            })
            .catch((error) => {
                console.log(error)
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
        setVoornaam('')
        setAchternaam('')
        setIsVasteNacht(false)
        setEditVoornaam('')
        setEditAchternaam('')
        setEditIsVasteNacht(false)
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
            <ToastContainer />
            <Container>
                <Row>
                    <Col>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Voornaam..."
                            value={voornaam}
                            onChange={(e) => setVoornaam(e.target.value)}
                        />
                    </Col>
                    <Col>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Achternaam..."
                            value={achternaam}
                            onChange={(e) => setAchternaam(e.target.value)}
                        />
                    </Col>
                    <Col>
                        <input
                            type="checkbox"
                            checked={isVasteNacht === true ? true : false}
                            value={isVasteNacht}
                            onChange={(e) => handleActiveChange(e)}
                        />
                        <label>Vaste Nacht?</label>
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
                    <Row>
                        <Col>
                            <input
                                type="text"
                                className="form-control"
                                placeholder="Voornaam..."
                                value={editVoornaam}
                                onChange={(e) => setEditVoornaam(e.target.value)}
                            />
                        </Col>
                        <Col>
                            <input
                                type="text"
                                className="form-control"
                                placeholder="Achternaam..."
                                value={editAchternaam}
                                onChange={(e) => setEditAchternaam(e.target.value)}
                            />
                        </Col>
                        <Col>
                            <input
                                type="checkbox"
                                checked={editIsVasteNacht === true ? true : false}
                                value={editIsVasteNacht}
                                onChange={(e) => handleEditActiveChange(e)}
                            />
                            <label>Vaste Nacht?</label>
                        </Col>
                    </Row>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleUpdate}>
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th></th>
                        <th>Voornaam</th>
                        <th>Achternaam</th>
                        <th>Vaste Nacht?</th>
                        <th>Veranderingen</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        data && data.length > 0 ?
                            data.map((item, index) => {
                                return (
                                    <tr key={index}>
                                        <td>{item.id}</td>
                                        <td>{item.voornaam}</td>
                                        <td>{item.achternaam}</td>
                                        <td>{(item.isVasteNacht) ? "Ja" : "Nee"}</td>
                                        <td>
                                            <Button className="btn btn-primary" onClick={() => handleEdit(item.id)}>Edit</Button>
                                            <Button className="btn btn-danger" onClick={() => handleDelete(item.id)}>Delete</Button>
                                        </td>
                                    </tr>
                                )
                            }) : 'No data found'}
                </tbody>
            </Table>
        </Fragment>
    );
}

export default ZorgkundigeCrud;