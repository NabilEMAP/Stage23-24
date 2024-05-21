import React, { useState } from 'react';
import axios from 'axios';
import { API_BASE_URL } from '../config';
import { IconButton } from '@mui/material';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFileExcel } from '@fortawesome/free-solid-svg-icons';

const DownloadExcel = ({ teamplanId }) => {
  const handleDownload = async () => {
      try {
          const response = await axios.get(`${API_BASE_URL}/excel/generate`, {
              params: { teamplanId },
              responseType: 'blob'
          });

          const url = window.URL.createObjectURL(new Blob([response.data]));
          const link = document.createElement('a');
          link.href = url;
          link.setAttribute('download', 'NurseSchedule.xlsx');
          document.body.appendChild(link);
          link.click();
          document.body.removeChild(link);
      } catch (error) {
          console.error('Error downloading the file', error);
      }
      console.log(teamplanId);
  };
  return (
    <IconButton
      size="medium"
      color="success"
      onClick={handleDownload}
    >
      <FontAwesomeIcon icon={faFileExcel} />
    </IconButton>
  );
};

export default DownloadExcel;
