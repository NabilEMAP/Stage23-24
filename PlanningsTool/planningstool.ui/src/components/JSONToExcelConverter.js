import React, { useEffect, useState } from 'react';
import * as XLSX from 'xlsx';
import axios from 'axios';
import { faFileExcel } from '@fortawesome/free-solid-svg-icons';
import { IconButton } from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { API_BASE_URL } from "../config";
import dayjs from 'dayjs';
import { toast } from 'react-toastify';

function JSONToExcelConverter(props) {
    const [data, setData] = useState([]);
    
    useEffect(() => {
        getData();
    }, []);

    const getData = () => {
        const API = `${API_BASE_URL}/Teamplans`;
        axios.get(API)
            .then((result) => {
                setData(result.data);
            })
            .catch((error) => {
                toast.warning(error.message + ': ' + API.split('/api/')[1]);
            })
    }

    return (
        <IconButton
            size="medium"
            color="success"
        >
            <FontAwesomeIcon icon={faFileExcel} />
        </IconButton>
    );
}

export default JSONToExcelConverter;