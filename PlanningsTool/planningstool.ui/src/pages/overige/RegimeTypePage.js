import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import { DataGrid, GridToolbar } from '@mui/x-data-grid';
import { Container, Typography } from "@mui/material";
import { API_BASE_URL } from "../../config";
import { toast } from 'react-toastify';

function RegimeTypePage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/RegimeTypes`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            });
    }

    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'name', headerName: 'Regime', flex: 1 },
        { field: 'countHours', headerName: 'Aantal Uren', flex: 1 },
    ];

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>RegimeType Lijst</Typography>
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

export default RegimeTypePage;
