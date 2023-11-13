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
import AddNurse from "../components/nurses/AddNurse";
import EditNurse from "../components/nurses/EditNurse";
import DeleteNurse from "../components/nurses/DeleteNurse";
import { Container, Typography } from "@mui/material";
import CancelIcon from '@mui/icons-material/Cancel';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import { API_BASE_URL } from "../config";

function NursePage() {
    const [data, setData] = useState([]);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: "asc" });
    const [dataChanged, setDataChanged] = useState(false);

    useEffect(() => {
        if (dataChanged) {
            getData();
            setDataChanged(false);
        }
        getData();
    }, [dataChanged]);

    const getData = () => {
        const API = `${API_BASE_URL}/Nurses`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            });
    }

    const hasDataChanged = (change) => {
        setDataChanged(change);
    };

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
                    <MyTC>{item.firstName}</MyTC>
                    <MyTC>{item.lastName}</MyTC>
                    <MyTC>{item.regimeType.name}</MyTC>
                    <MyTC>
                        {item.isFixedNight ? <CheckCircleIcon fontSize="large" color="success" /> : <CancelIcon fontSize="large" color="error" />}
                    </MyTC>
                    <MyTC style={{ width: '150px' }}>
                        <EditNurse id={item.id} dataChanged={hasDataChanged} />
                        <DeleteNurse id={item.id} dataChanged={hasDataChanged} />
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Zorgkundige Lijst</Typography>
                    <AddNurse dataChanged={hasDataChanged} />
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC onClick={() => requestSort("id")}>Id</MyTC>
                                <MyTC onClick={() => requestSort("firstName")}>Voornaam</MyTC>
                                <MyTC onClick={() => requestSort("lastName")}>Achternaam</MyTC>
                                <MyTC onClick={() => requestSort("regimeType.name")}>Regime</MyTC>
                                <MyTC onClick={() => requestSort("isFixedNight")}>Vaste Nacht</MyTC>
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

export default NursePage;
