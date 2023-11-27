import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import { DataGrid } from '@mui/x-data-grid';
import { Container, Typography } from "@mui/material";
import { API_BASE_URL } from "../config";

function ShiftPage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/Shifts`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            });
    }

    const columns = [
        { field: 'id', headerName: 'Id', flex: 1 },
        { field: 'shiftType', headerName: 'Shift', flex: 1, valueGetter: (params) => params.row.shiftType.name },
        { field: 'starttime', headerName: 'Starttijd', flex: 1, valueFormatter: (params) => formatTime(params.value) },
        { field: 'endtime', headerName: 'Eindtijd', flex: 1, valueFormatter: (params) => formatTime(params.value) },
    ];
    
    const formatTime = (timeString) => {
        const date = new Date(`2000-01-01T${timeString}`);
        return date.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
    };

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Vaste Shift Lijst</Typography>
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

export default ShiftPage;
