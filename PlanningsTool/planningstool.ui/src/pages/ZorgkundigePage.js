import axios from "axios";
import React, { Fragment, useEffect, useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { MyTC, MyTR } from "../components/MyTable";
import AddZorgkundige from "../components/zorgkundigen/AddZorgkundige";
import EditZorgkundige from "../components/zorgkundigen/EditZorgkundige";
import DeleteZorgkundige from "../components/zorgkundigen/DeleteZorgkundige";

function ZorgkundigePage() {
    const [data, setData] = useState([]);

    useEffect(() => {
        getData();
    }, [data]);

    const getData = () => {
        const API = 'https://localhost:8000/api/Zorgkundigen/details'
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                console.log(error);
            })
    }

    return (
        <Fragment>
            <AddZorgkundige />
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 700 }} aria-label="customized table">
                    <TableHead>
                        <TableRow>
                            <MyTC></MyTC>
                            <MyTC>Voornaam</MyTC>
                            <MyTC>Achternaam</MyTC>
                            <MyTC>Vaste Nacht?</MyTC>
                            <MyTC>Veranderingen</MyTC>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {data && data.length > 0 ? data.map((item, index) => {
                            return (
                                <MyTR key={index}>
                                    <MyTC>{item.id}</MyTC>
                                    <MyTC>{item.voornaam}</MyTC>
                                    <MyTC>{item.achternaam}</MyTC>
                                    <MyTC>{(item.isVasteNacht) ? "Ja" : "Nee"}</MyTC>
                                    <MyTC>
                                        <EditZorgkundige id={item.id} />
                                        <DeleteZorgkundige id={item.id} />
                                    </MyTC>
                                </MyTR>
                            )
                        }) : 'No data found'}
                    </TableBody>
                </Table>
            </TableContainer>
        </Fragment>
    );
}

export default ZorgkundigePage;