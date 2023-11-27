import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import { DataGrid } from '@mui/x-data-grid';
import { Container, Typography, Tooltip, IconButton } from "@mui/material";
import { format } from 'date-fns';
import nlBE from "date-fns/locale/nl-BE";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCircleInfo } from "@fortawesome/free-solid-svg-icons";
import { API_BASE_URL } from "../config";
import AddVacation from "../components/vacations/AddVacation";
import EditVacation from "../components/vacations/EditVacation";
import DeleteVacation from "../components/vacations/DeleteVacation";
import '../App.css';

function VacationPage() {
    const [data, setData] = useState([]);

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
            });
    };

    const nurseFullname = (name) => {
        return name.nurse.firstName + ' ' + name.nurse.lastName;
    };

    const showReason = (item) => {
        return (
            <p>Reden: {item.reason}</p>
        );
    };


    const renderTooltip = (item) => {
        return (
            <Tooltip title={showReason(item.row)} placement="left-end">
                <IconButton style={{ marginRight: '6px' }} size="medium" color="inherit">
                    <FontAwesomeIcon icon={faCircleInfo} />
                </IconButton>
                {item.value}
            </Tooltip>
        );
    };

    const renderChanges = (item) => (
        <>
            <EditVacation id={item.id} onUpdate={handleUpdate} />
            <DeleteVacation id={item.id} onUpdate={handleUpdate} />
        </>
    );


    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'nurseFullname', headerName: 'Zorgkundige', flex: 1.5, renderCell: renderTooltip, },
        { field: 'startdate', headerName: 'Startdatum', flex: 1.25, valueGetter: (params) => format(new Date(params.row.startdate), 'dd MMMM yyyy', { locale: nlBE }) },
        { field: 'enddate', headerName: 'Einddatum', flex: 1.25, valueGetter: (params) => format(new Date(params.row.enddate), 'dd MMMM yyyy', { locale: nlBE }) },
        { field: 'vacationType', headerName: 'Verlof', flex: 0.75, valueGetter: (params) => params.row.vacationType.name },
        {
            field: 'actions',
            headerName: 'Veranderingen',
            flex: 1,
            renderCell: (params) => renderChanges(params.row),
        },
    ];

    const rows = data.map((item) => ({
        id: item.id,
        nurseFullname: nurseFullname(item),
        startdate: item.startdate,
        enddate: item.enddate,
        vacationType: item.vacationType,
        reason: item.reason,
    }));

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Verlof Lijst</Typography>
                    <AddVacation onUpdate={handleUpdate} />
                </div>
                <div>
                    <DataGrid
                        rows={rows}
                        columns={columns}
                        pageSize={5}
                        rowSelection={false}
                        rowHeight={69}
                    />
                </div>
            </Container>
        </Fragment>
    );
}

export default VacationPage;
