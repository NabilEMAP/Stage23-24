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
import { API_BASE_URL } from "../../config";
import ShiftPage from "../ShiftPage";

function ShiftTypePage() {
    const [data, setData] = useState([]);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: "asc" });

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/ShiftTypes`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    const requestSort = (key) => {
        let direction = 'asc';
        if (sortConfig && sortConfig.key === key && sortConfig.direction === 'asc') {
            direction = 'desc';
        }
        setSortConfig({ key, direction });
    }

    const sortedData = [...data];
    if (sortConfig !== null) {
        sortedData.sort((a, b) => {
            if (sortConfig.key === null) return 0;
            const keys = sortConfig.key.split('.');
            let aValue = a;
            let bValue = b;
            for (const key of keys) {
                aValue = aValue[key];
                bValue = bValue[key];
            }
            if (aValue < bValue) return sortConfig.direction === 'asc' ? -1 : 1;
            if (aValue > bValue) return sortConfig.direction === 'asc' ? 1 : -1;
            return 0;
        });
    }

    const renderTableData = () => {
        if (sortedData && sortedData.length > 0) {
            return sortedData.map((item, index) => (
                <MyTR key={index}>
                    <MyTC>{item.id}</MyTC>
                    <MyTC>{item.name}</MyTC>
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>ShiftType Lijst</Typography>
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC onClick={() => requestSort("id")}>Id</MyTC>
                                <MyTC onClick={() => requestSort("name")}>Shift</MyTC>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {renderTableData()}
                        </TableBody>
                    </Table>
                </TableContainer>
                <ShiftPage />
            </Container>
        </Fragment>
    );
}

export default ShiftTypePage;