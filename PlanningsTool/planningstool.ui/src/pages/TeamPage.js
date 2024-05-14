import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';
import AddTeam from "../components/teams/AddTeam";
import EditTeam from "../components/teams/EditTeam";
import DeleteTeam from "../components/teams/DeleteTeam";
import { Container, Typography } from "@mui/material";
import { API_BASE_URL } from "../config";
import { DataGrid } from '@mui/x-data-grid';
import '../App.css';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';

function TeamPage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const handleUpdate = () => {
        getData();
    };

    const getData = () => {
        const API = `${API_BASE_URL}/Teams`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            });
    }

    const renderChanges = (item) => (
        <div style={{ width: '150px' }}>
            <EditTeam id={item.id} onUpdate={handleUpdate} />
            <DeleteTeam id={item.id} onUpdate={handleUpdate} />
        </div>
    );

    const renderTeamName = (params) => (
        <Link to={`/team/${params.row.id}`} style={{ textDecoration: 'none', color: 'inherit' }}>
            {params.value}
        </Link>
    );

    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'teamName', headerName: 'Teamnaam', flex: 1, renderCell: renderTeamName },
        {
            field: 'actions',
            headerName: 'Veranderingen',
            flex: 1,
            renderCell: (params) => renderChanges(params)
        },
    ];


    const rows = data.map((item) => ({
        id: item.id,
        teamName: item.teamName,
    }));

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Teams</Typography>
                    <AddTeam onUpdate={handleUpdate} />
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

export default TeamPage;