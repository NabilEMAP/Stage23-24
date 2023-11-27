import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import { DataGrid } from '@mui/x-data-grid';
import { Container, Typography } from "@mui/material";
import { API_BASE_URL } from "../../config";
import ShiftPage from "../ShiftPage";

function ShiftTypePage() {
    const [data, setData] = useState([]);

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
            });
    }

    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'name', headerName: 'Shift', flex: 1 },
    ];

    return (
        <>
            <Fragment>
                <Container>
                    <div style={{ margin: '24px 0px' }}>
                        <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>ShiftType Lijst</Typography>
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
            <ShiftPage />
        </>
    );
}

export default ShiftTypePage;
