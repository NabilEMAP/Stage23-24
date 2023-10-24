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
import AddZorgkundige from "../components/zorgkundigen/AddZorgkundige";
import EditZorgkundige from "../components/zorgkundigen/EditZorgkundige";
import DeleteZorgkundige from "../components/zorgkundigen/DeleteZorgkundige";
import { Container, Typography } from "@mui/material";
import CancelIcon from '@mui/icons-material/Cancel';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';

function ZorgkundigePage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, [data]);

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

    const renderTableData = () => {
        if (data && data.length > 0) {
            return data.map((item, index) => (
                <MyTR key={index}>
                    <MyTC>{item.id}</MyTC>
                    <MyTC>{item.voornaam}</MyTC>
                    <MyTC>{item.achternaam}</MyTC>
                    <MyTC>{item.regimeType.regime}</MyTC>
                    <MyTC>
                        {item.isVasteNacht ? <CheckCircleIcon color="success" /> : <CancelIcon color="error" />}
                    </MyTC>
                    <MyTC style={{ width: '150px' }}>
                        <EditZorgkundige id={item.id} />
                        <DeleteZorgkundige id={item.id} />
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }} >Zorgkundige Lijst</Typography>
                    <AddZorgkundige />
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC>Id</MyTC>
                                <MyTC>Voornaam</MyTC>
                                <MyTC>Achternaam</MyTC>
                                <MyTC>Regime</MyTC>
                                <MyTC>Vaste Nacht?</MyTC>
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

export default ZorgkundigePage;