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
import { Container, Stack, Typography } from "@mui/material";
import ClearFeestdagList from "../../components/feestdagen/ClearFeestdagList";
import GenerateFeestdagen from "../../components/feestdagen/GenerateFeestdagen";
import { format } from 'date-fns';

function FeestdagPage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, [data]);

    const getData = () => {
        const API = 'https://localhost:8000/api/Feestdagen'
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
                    <MyTC>{item.naam}</MyTC>
                    <MyTC>{format(new Date(item.datum), 'dd/MM/yyyy')}</MyTC>
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }} >Feestdag Lijst</Typography>
                    <Stack
                        direction="row"
                        spacing={2}
                        style={{ float: 'right' }}
                    >
                        <ClearFeestdagList />
                        <GenerateFeestdagen />
                    </Stack>
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC>Id</MyTC>
                                <MyTC>Feestdag</MyTC>
                                <MyTC>Datum</MyTC>
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

export default FeestdagPage;