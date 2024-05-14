import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import { DataGrid, GridToolbar } from '@mui/x-data-grid';
import { Container, Stack, Typography } from "@mui/material";
import ClearHolidayList from "../../components/holidays/ClearHolidayList";
import GenerateHolidays from "../../components/holidays/GenerateHolidays";
import AddHoliday from "../../components/holidays/AddHoliday";
import EditHoliday from "../../components/holidays/EditHoliday";
import DeleteHoliday from "../../components/holidays/DeleteHoliday";
import { format } from 'date-fns';
import nlBE from "date-fns/locale/nl-BE";
import { API_BASE_URL } from "../../config";
import { toast } from 'react-toastify';


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
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            });
    }

    const renderChanges = (item) => (
        <>
            <EditHoliday id={item.id} onUpdate={handleUpdate} />
            <DeleteHoliday id={item.id} onUpdate={handleUpdate} />
        </>
    );

    const columns = [
        { field: 'id', headerName: 'Id', flex: 1 },
        { field: 'name', headerName: 'Feestdag', flex: 1 },
        {
            field: 'date',
            headerName: 'Datum',
            flex: 1,
            valueGetter: (params) => format(new Date(params.row.date), 'dd MMMM yyyy', { locale: nlBE }),
        },
        {
            field: 'actions',
            headerName: 'Veranderingen',
            flex: 1,
            renderCell: (params) => renderChanges(params.row),
        },
    ];

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
                        <AddHoliday buttonColor='success' onUpdate={handleUpdate} />
                        <GenerateHolidays onUpdate={handleUpdate} />
                        <ClearHolidayList onUpdate={handleUpdate} />
                    </Stack>
                </div>
                <div>
                    <DataGrid
                        rows={data}
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

export default HolidayPage;
