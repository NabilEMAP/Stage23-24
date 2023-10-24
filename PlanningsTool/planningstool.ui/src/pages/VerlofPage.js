import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { MyTC, MyTR } from "../components/MyTable";
import AddVerlof from "../components/verloven/AddVerlof";
import EditVerlof from "../components/verloven/EditVerlof";
import DeleteVerlof from "../components/verloven/DeleteVerlof";
import { Container, Typography, Tooltip } from "@mui/material";
import { format } from 'date-fns';
function VerlofPage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, [data]);

    const getData = () => {
        const API = 'https://localhost:8000/api/Verloven/details'
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const zorgkundigeNaam = (naam) => { 
        return naam.zorgkundige.voornaam + ' ' + naam.zorgkundige.achternaam;
    }

    const renderTooltip = (item) => {
        return (
            <p>
                Zorgkundige: {zorgkundigeNaam(item)}<br />
                Startdatum: {format(new Date(item.startdatum), 'dd/MM/yyyy')}<br />
                Einddatum: {format(new Date(item.einddatum), 'dd/MM/yyyy')}<br />
                Verlof: {item.verlofType.verlof}<br />
                Reden: {item.reden}<br />
            </p>
        );
    }

    const renderTableData = () => {
        if (data && data.length > 0) {
            return data.map((item, index) => (
                <MyTR key={index}>
                    <MyTC>{item.id}</MyTC>
                    <MyTC>
                        <Tooltip title={renderTooltip(item)} placement="right-end">
                            {zorgkundigeNaam(item)}
                        </Tooltip>
                    </MyTC>
                    <MyTC>{format(new Date(item.startdatum), 'dd/MM/yyyy')}</MyTC>
                    <MyTC>{format(new Date(item.einddatum), 'dd/MM/yyyy')}</MyTC>
                    <MyTC>{item.verlofType.verlof}</MyTC>
                    <MyTC style={{ width: '150px' }}>
                        <EditVerlof id={item.id} />
                        
                        <DeleteVerlof id={item.id} />
                    </MyTC>
                </MyTR>
            ));
        } else {
            return <TableRow><MyTC colSpan={5}>No data found</MyTC></TableRow>;
        }
    }

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }} >Verlof Lijst</Typography>
                    <AddVerlof />
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC>Id</MyTC>
                                <MyTC>Zorgkundige</MyTC>
                                <MyTC>Startdatum</MyTC>
                                <MyTC>Einddatum</MyTC>
                                <MyTC>Verlof</MyTC>
                                <MyTC style={{ width: '150px' }}>Veranderingen</MyTC>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {renderTableData()}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Container>
        </Fragment>
    );
}

export default VerlofPage;