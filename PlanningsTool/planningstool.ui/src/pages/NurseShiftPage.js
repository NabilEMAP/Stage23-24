import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import { DataGrid } from '@mui/x-data-grid';
import { Container, Typography } from "@mui/material";
import { format } from 'date-fns';
import nlBE from "date-fns/locale/nl-BE";
import { API_BASE_URL } from "../config";
import AddNurseShift from "../components/nurseShifts/AddNurseShift";
import EditNurseShift from "../components/nurseShifts/EditNurseShift";
import DeleteNurseShift from "../components/nurseShifts/DeleteNurseShift";
import { toast } from 'react-toastify';

function NurseShiftPage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const handleUpdate = () => {
        getData();
    };

    const getData = () => {
        const API = `${API_BASE_URL}/NurseShifts`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            });
    }

    const rows = data.map((item) => ({
        id: item.id,
        nurseFullName: item.nurse.firstName + ' ' + item.nurse.lastName,
        regimeType: item.nurse.regimeType.name,
        shift: item.shift,
        date: item.date,
    }));

    const renderChanges = (item) => (
        <div style={{ width: '150px' }}>
            <EditNurseShift id={item.id} onUpdate={handleUpdate} />
            <DeleteNurseShift id={item.id} onUpdate={handleUpdate} />
        </div>
    );

    const formatTime = (timeString) => {
        const date = new Date(`2000-01-01T${timeString}`);
        return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    };

    const renderShiftCell = (params) => (
        `${params.row.shift.shiftType.name} - ${formatTime(params.row.shift.starttime)} - ${formatTime(params.row.shift.endtime)}`
    );

    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'nurseFullName', headerName: 'Zorgkundige', flex: 1 },
        { field: 'regimeType', headerName: 'Regime', flex: 1 },
        { field: 'shift', headerName: 'Shift', flex: 1.25, renderCell: renderShiftCell },
        { field: 'date', headerName: 'Datum', flex: 1, valueGetter: (params) => format(new Date(params.row.date), 'dd MMMM yyyy', { locale: nlBE }) },
        { field: 'actions', headerName: 'Veranderingen', flex: 1, renderCell: (params) => renderChanges(params.row) },
    ];

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Zorgkundige Shift Lijst</Typography>
                    <AddNurseShift buttonColor='success' onUpdate={handleUpdate} />
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

export default NurseShiftPage;
