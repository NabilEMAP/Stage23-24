import React, { useState } from 'react';
import axios from 'axios';
import { API_BASE_URL } from '../config';
import { IconButton } from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFileExcel } from '@fortawesome/free-solid-svg-icons';

const DownloadExcel = () => {
  return (
    <IconButton
      size="medium"
      color="success"
    >
      <FontAwesomeIcon icon={faFileExcel} />
    </IconButton>
  );
};

export default DownloadExcel;
