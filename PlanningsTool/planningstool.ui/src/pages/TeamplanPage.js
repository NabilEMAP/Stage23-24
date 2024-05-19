import React, { Fragment, useEffect, useState } from "react";
import axios from "axios";
import 'bootstrap/dist/css/bootstrap.min.css';
import AddTeamplan from "../components/teamplans/AddTeamplan";
import EditTeamplan from "../components/teamplans/EditTeamplan";
import DeleteTeamplan from "../components/teamplans/DeleteTeamplan";
import { Container, Typography } from "@mui/material";
import { API_BASE_URL } from "../config";
import { DataGrid } from '@mui/x-data-grid';
import '../App.css';
import { Link } from 'react-router-dom';
import { toast } from 'react-toastify';
import dayjs from "dayjs";
import JSONToExcelConverter from "../components/JSONToExcelConverter";

function TeamplanPage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, []);

    const handleUpdate = () => {
        getData();
    };

    const getData = () => {
        const API = `${API_BASE_URL}/Teamplans`;
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
            <EditTeamplan id={item.id} onUpdate={handleUpdate} />
            <DeleteTeamplan id={item.id} onUpdate={handleUpdate} />            
            <JSONToExcelConverter id={item.id} />
        </div>
    );

    const renderName = (params) => (
        <Link to={`/teamplan/${params.row.id}`} style={{ textDecoration: 'none', color: 'inherit' }}>
            {params.value}
        </Link>
    );

    const columns = [
        { field: 'id', headerName: 'Id', flex: 0.5 },
        { field: 'name', headerName: 'Naam', flex: 1.4, renderCell: renderName },
        { field: 'planFor', headerName: 'Planning voor', flex: 0.6, },
        { field: 'createdOn', headerName: 'Aangemaakt op', flex: 1, },
        {
            field: 'actions',
            headerName: 'Veranderingen',
            flex: 1,
            renderCell: (params) => renderChanges(params)
        },
    ];


    const rows = data.map((item) => ({
        id: item.id,
        name: item.name,
        planFor: dayjs(item.planFor).format('YYYY-MM'),
        createdOn: dayjs(item.createdOn).format('YYYY-MM-DD HH:mm:ss'),
    }));

    return (
        <Fragment>
            <Container>
                <div style={{ margin: '24px 0px' }}>
                    <Typography variant="h5" style={{ width: 'fit-content', verticalAlign: 'sub', display: 'inline-block' }}>Teamplans</Typography>
                    <AddTeamplan onUpdate={handleUpdate} />
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

export default TeamplanPage;