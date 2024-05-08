import moment from "moment";
import Calendar from "../Calendar";
import React, { Fragment, useEffect, useState } from "react";
import { API_BASE_URL } from "../../config";
import axios from "axios";

function AdvancedCalendar() {
  const [vacationData, setVacationData] = useState([]);
  const [nurseShiftData, setNurseShiftData] = useState([]);
  const [holidayData, setHolidayData] = useState([]);

  useEffect(() => {
    getVacationData();
    getNurseShiftData();
    getHolidayData();
  }, []);

  const getVacationData = () => {
    const API = `${API_BASE_URL}/Vacations/details`;
    axios.get(API)
      .then((result) => {
        setVacationData(result.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const getNurseShiftData = () => {
    const API = `${API_BASE_URL}/NurseShifts`;
    axios.get(API)
      .then((result) => {
        setNurseShiftData(result.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const getHolidayData = () => {
    const API = `${API_BASE_URL}/Holidays`;
    axios.get(API)
      .then((result) => {
        setHolidayData(result.data);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const formatVacationData = (data) => {
    return data.map(vacation => ({
      start: moment(vacation.startdate).toDate(),
      end: moment(vacation.enddate).add(1, 'day').toDate(),
      title: `Vacation - ${vacation.nurse.firstName} ${vacation.nurse.lastName}`,
      data: {
        type: "Vacation",
      },
    }));
  };

  const formatNurseShiftData = (data) => {
    return data.map(nurseShift => ({
      start: moment(nurseShift.date).toDate(),
      end: moment(nurseShift.date).toDate(),
      title: `Shift - ${nurseShift.nurse.firstName} ${nurseShift.nurse.lastName}`,
      data: {
        type: "Shift",
      },
    }));
  };

  const formatHolidayData = (data) => {
    return data.map(holiday => ({
      start: moment(holiday.date).toDate(),
      end: moment(holiday.date).toDate(),
      title: `${holiday.name}`,
      data: {
        type: "Holiday",
      },
    }));
  };

  const events = [
    ...formatVacationData(vacationData),
    ...formatNurseShiftData(nurseShiftData),
    ...formatHolidayData(holidayData),
  ];

  const components = {
    event: (props) => {
      const eventType = props?.event?.data?.type;
      switch (eventType) {
        case "Holiday":
          return (
            <div
              style={{ background: "tomato", color: "black", height: "100%" }}
            >
              {props.title}
            </div>
          );
        case "Shift":
          return (
            <div
              style={{ background: "lightgreen", color: "black", height: "100%" }}
            >
              {props.title}
            </div>
          );
        case "Vacation":
          return (
            <div
              style={{ background: "orange", color: "black", height: "100%" }}
            >
              {props.title}
            </div>
          );
        default:
          return null;
      }
    },
  };
  return <Calendar events={events} components={components} />;
}
export default AdvancedCalendar;