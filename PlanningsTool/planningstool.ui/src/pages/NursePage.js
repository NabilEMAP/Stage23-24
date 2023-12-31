import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';
import AddNurse from "../components/nurses/AddNurse";
import EditNurse from "../components/nurses/EditNurse";
import DeleteNurse from "../components/nurses/DeleteNurse";
import { Container, Typography } from "@mui/material";
import CancelIcon from '@mui/icons-material/Cancel';
import CheckCircleIcon from '@mui/icons-material/CheckCircle';
import { API_BASE_URL } from "../config";
import { DataGrid } from '@mui/x-data-grid';
import '../App.css';

function NursePage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const handleUpdate = () => {
        getData();
    };

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

    const showIsFixedNight = (params) => {
        return params.value ? (
            <CheckCircleIcon fontSize="large" color="success" />
        ) : (
            <CancelIcon fontSize="large" color="error" />
        );
    };

    const renderChanges = (item) => (
        <div style={{ width: '150px' }}>
            <EditNurse id={item.id} onUpdate={handleUpdate} />
            <DeleteNurse id={item.id} onUpdate={handleUpdate} />
        </div>
    );

    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'firstName', headerName: 'Voornaam', flex: 1 },
        { field: 'lastName', headerName: 'Achternaam', flex: 1 },
        {
            field: 'regimeType',
            headerName: 'Regime',
            flex: 1,
        },
        {
            field: 'isFixedNight',
            headerName: 'Vaste Nacht',
            flex: 1,
            renderCell: showIsFixedNight,
        },
        {
            field: 'actions',
            headerName: 'Veranderingen',
            flex: 1,
            renderCell: (params) => renderChanges(params)
        },
    ];
    
    const rows = data.map((item) => ({
        id: item.id,
        firstName: item.firstName,
        lastName: item.lastName,
        regimeType: item.regimeType.name,
        isFixedNight: item.isFixedNight,
    }));

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Zorgkundige Lijst</Typography>
                    <AddNurse onUpdate={handleUpdate} />
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

export default NursePage;