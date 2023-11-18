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
import AddVacation from "../components/vacations/AddVacation";
import EditVacation from "../components/vacations/EditVacation";
import DeleteVacation from "../components/vacations/DeleteVacation";
import { Container, Typography, Tooltip, IconButton } from "@mui/material";
import { format } from 'date-fns';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCircleInfo } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../config";


function VacationPage() {
    const [data, setData] = useState([]);
    const [sortConfig, setSortConfig] = useState({ key: null, direction: "asc" });

    useEffect(() => {
        getData();
    }, []);

    const handleUpdate = () => {
        getData();
      };

    const getData = () => {
        const API = `${API_BASE_URL}/Vacations/details`;
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

    const nurseFullname = (name) => {
        return name.nurse.firstName + ' ' + name.nurse.lastName;
    }

    const renderTooltip = (item) => {
        return (
            <p>Reden: {item.reason}</p>
        );
    }

    const renderTableData = () => {
        if (sortedData && sortedData.length > 0) {
            return sortedData.map((item, index) => (
                <MyTR key={index}>
                    <MyTC>{item.id}</MyTC>
                    <MyTC onClick={() => requestSort("nurse.firstName")}>
                        <Tooltip title={renderTooltip(item)} placement="left-end">
                            <IconButton style={{marginRight:'6px'}} size="medium" color="inherit">
                                <FontAwesomeIcon icon={faCircleInfo} />
                            </IconButton>
                        </Tooltip>
                        {nurseFullname(item)}
                    </MyTC>
                    <MyTC>{format(new Date(item.startdate), 'dd/MM/yyyy')}</MyTC>
                    <MyTC>{format(new Date(item.enddate), 'dd/MM/yyyy')}</MyTC>
                    <MyTC>{item.vacationType.name}</MyTC>
                    <MyTC style={{ width: '175px' }}>
                        <EditVacation id={item.id} onUpdate={handleUpdate}/>
                        <DeleteVacation id={item.id} onUpdate={handleUpdate}/>
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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Verlof Lijst</Typography>
                    <AddVacation onUpdate={handleUpdate}/>
                </div>
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 700 }} aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <MyTC onClick={() => requestSort("id")}>Id</MyTC>
                                <MyTC onClick={() => requestSort("nurse.firstName")}>Zorgkundige</MyTC>
                                <MyTC onClick={() => requestSort("starddate")}>Startdatum</MyTC>
                                <MyTC onClick={() => requestSort("enddate")}>Einddatum</MyTC>
                                <MyTC onClick={() => requestSort("vacationType.name")}>Verlof</MyTC>
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

export default VacationPage;