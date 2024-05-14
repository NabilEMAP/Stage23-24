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
import { useParams } from 'react-router-dom';
import { toast } from 'react-toastify';

function NursePage() {
    const { teamId } = useParams();
    const [data, setData] = useState([]);
    const [teamName, setTeamName] = useState('');

    useEffect(() => {
        if (teamId) {
            getData(teamId);
            getTeamName(teamId);
        }
    }, [teamId]);

    const handleUpdate = () => {
        if (teamId) {
            getData(teamId);
        }
    };

    const getData = (teamId) => {
        const API = `${API_BASE_URL}/Nurses`;
        axios.get(API)
            .then((result) => {
                const nurses = result.data.filter(nurse => nurse.teamId == teamId);
                setData(nurses);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            });
    }

    const getTeamName = (teamId) => {
        const API = `${API_BASE_URL}/Teams/${teamId}`;
        axios.get(API)
            .then((result) => {
                setTeamName(result.data.teamName);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            });
    };

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
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Zorgkundige Lijst van: {teamName}</Typography>
                    <AddNurse onUpdate={handleUpdate} teamId={teamId} />
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