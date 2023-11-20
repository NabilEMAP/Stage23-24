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
import ClearHolidayList from "../../components/holidays/ClearHolidayList";
import GenerateHolidays from "../../components/holidays/GenerateHolidays";
import { format } from 'date-fns';
import { API_BASE_URL } from "../../config";

function HolidayPage() {
    const [data, setData] = useState([]);
    
    useEffect(() => {
        getData();
    }, []);

    const handleUpdate = () => {
        getData();
    };

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

    const renderTableData = () => {
        if (data && data.length > 0) {
            return data.map((item, index) => (
                <MyTR key={index}>
                    <MyTC>{item.id}</MyTC>
                    <MyTC>{item.name}</MyTC>
                    <MyTC>{format(new Date(item.date), 'dd/MM/yyyy')}</MyTC>
                </MyTR>
            ));
        } else {
            return <TableRow><MyTC colSpan={5}>Geen data gevonden</MyTC></TableRow>;
        }
    }

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Feestdag Lijst</Typography>
                    <Stack
                        direction="row"
                        spacing={2}
                        style={{ float: 'right' }}
                    >
                        <ClearHolidayList onUpdate={handleUpdate} />
                        <GenerateHolidays onUpdate={handleUpdate} />
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

export default HolidayPage;