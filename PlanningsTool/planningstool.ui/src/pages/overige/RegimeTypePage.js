import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { MyTC, MyTR } from "../../components/MyTable";
import { Container, Typography } from "@mui/material";

function RegimeTypePage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, [data]);

    const getData = () => {
        const API = 'https://localhost:8000/api/RegimeTypes'
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
                    <MyTC>{item.regime}</MyTC>
                    <MyTC>{item.aantalUren}</MyTC>
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }} >Regime Lijst</Typography>
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC>Id</MyTC>
                                <MyTC>Regime</MyTC>
                                <MyTC>Aantal Uren</MyTC>
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

export default RegimeTypePage;