import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { MyTC, MyTR } from "../components/MyTable";
import AddNurseShift from "../components/nurseShifts/AddNurseShift";
import EditNurseShift from "../components/nurseShifts/EditNurseShift";
import DeleteNurseShift from "../components/nurseShifts/DeleteNurseShift";
import { Container, Typography } from "@mui/material";
import { format } from 'date-fns';
import { API_BASE_URL } from "../config";

function NurseShiftPage() {
    const [data, setData] = useState([]);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: "asc" });

    useEffect(() => {
        getData();
    }, [data]);

    const getData = () => {
        const API = `${API_BASE_URL}/NurseShifts`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            });
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
                    <MyTC>{item.nurse.firstName + ' ' + item.nurse.lastName}</MyTC>
                    <MyTC>{item.nurse.regimeType.name}</MyTC>
                    <MyTC>{
                        item.shift.shiftType.name + ' - ' +
                        item.shift.starttime + ' - ' +
                        item.shift.endtime
                    }
                    </MyTC>
                    <MyTC>{format(new Date(item.date), 'dd/MM/yyyy')}</MyTC>
                    <MyTC style={{ width: '150px' }}>
                        <EditNurseShift id={item.id} />
                        <DeleteNurseShift id={item.id} />
                    </MyTC>
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Zorgkundige Shift Lijst</Typography>
                    <AddNurseShift />
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC onClick={() => requestSort("id")}>Id</MyTC>
                                <MyTC onClick={() => requestSort("nurse.firstName")}>Zorgkundige</MyTC>
                                <MyTC onClick={() => requestSort("nurse.regimeType.name")}>Regime</MyTC>
                                <MyTC onClick={() => requestSort("shift.shiftType.shift")}>Shift</MyTC>
                                <MyTC onClick={() => requestSort("date")}>Datum</MyTC>
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

export default NurseShiftPage;
