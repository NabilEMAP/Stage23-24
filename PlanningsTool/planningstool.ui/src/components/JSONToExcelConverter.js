import React from 'react';
import XLSX from 'xlsx';

function JSONToExcelConverter({ jsonData }) {
  const convertJSONToExcel = (jsonData, month) => {
    // Parse JSON data
    const users = JSON.parse(jsonData);

    // Determine the range of days within the desired month
    const startDate = new Date(month);
    const endDate = new Date(startDate.getFullYear(), startDate.getMonth() + 1, 0);
    const daysInMonth = [];
    for (let d = startDate; d <= endDate; d.setDate(d.getDate() + 1)) {
      daysInMonth.push(new Date(d));
    }

    // Create worksheet
    const ws = XLSX.utils.aoa_to_sheet([['User', ...daysInMonth.map(day => day.getDate())]]);

    // Populate rows with user data
    users.forEach((user, index) => {
      const row = [user.name];
      daysInMonth.forEach(day => {
        // Add user data for each day
        // Example: row.push(user.data[day.toISOString()]);
        row.push(""); // Placeholder for user data
      });
      XLSX.utils.sheet_add_aoa(ws, [row], {origin: -1});
    });

    // Create workbook
    const wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Users');

    // Save workbook as Excel file
    XLSX.writeFile(wb, 'users.xlsx');
  };

  return (
    <div>
      <button onClick={() => convertJSONToExcel(jsonData, '2024-05')}>Export to Excel</button>
    </div>
  );
}

export default JSONToExcelConverter;

{/*<JSONToExcelConverter jsonData={yourJSONData} />*/}