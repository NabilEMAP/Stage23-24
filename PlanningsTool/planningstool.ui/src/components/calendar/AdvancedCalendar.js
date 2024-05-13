import moment from "moment";
import Calendar from "../Calendar";
import React, { useEffect, useState } from "react";
import { API_BASE_URL } from "../../config";
import axios from "axios";
import Modal from 'react-bootstrap/Modal';
import EditVacation from '../vacations/EditVacation';
import DeleteVacation from '../vacations/DeleteVacation';
import EditNurseShift from '../nurseShifts/EditNurseShift';
import DeleteNurseShift from '../nurseShifts/DeleteNurseShift';
import EditHoliday from '../holidays/EditHoliday';
import DeleteHoliday from '../holidays/DeleteHoliday';

function AdvancedCalendar() {
  const [vacationData, setVacationData] = useState([]);
  const [nurseShiftData, setNurseShiftData] = useState([]);
  const [holidayData, setHolidayData] = useState([]);
  const [selectedEvent, setSelectedEvent] = useState(null);
  const [showModal, setShowModal] = useState(false);

  useEffect(() => {
    getVacationData();
    getNurseShiftData();
    getHolidayData();
  }, []);

  const handleEventSelect = (event) => {
    setSelectedEvent(event);
    console.log(event);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };

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
        id: vacation.id,
      },
    }));
  };
  const formatNurseShiftData = (data) => {
    return data.map(nurseShift => ({
      start: moment(nurseShift.date).add(nurseShift.shift.starttime, 'hours').toDate(),
      end: moment(nurseShift.date).add(nurseShift.shift.endtime, 'hours').toDate(),
      title: `Shift - ${nurseShift.nurse.firstName} ${nurseShift.nurse.lastName}`,
      data: {
        type: "Shift",
        id: nurseShift.id,
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
        id: holiday.id,
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
  return (
    <>
      <Calendar
        events={events}
        components={components}
        onSelectEvent={handleEventSelect}
      />
      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Selected Event</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {selectedEvent && (
            <>
              <p>{selectedEvent.title}</p>
              {selectedEvent.data.type === "Vacation" && (
                <>
                  <EditVacation id={selectedEvent.data.id} onUpdate={getVacationData} />
                  <DeleteVacation id={selectedEvent.data.id} onUpdate={getVacationData} />
                </>
              )}
              {selectedEvent.data.type === "Shift" && (
                <>
                  <EditNurseShift id={selectedEvent.data.id} onUpdate={getNurseShiftData} />
                  <DeleteNurseShift id={selectedEvent.data.id} onUpdate={getNurseShiftData} />
                </>
              )}
              {selectedEvent.data.type === "Holiday" && (
                <>
                  <EditHoliday id={selectedEvent.data.id} onUpdate={getHolidayData} />
                  <DeleteHoliday id={selectedEvent.data.id} onUpdate={getHolidayData} />
                </>
              )}
            </>
          )}
        </Modal.Body>
      </Modal>
    </>
  );
}
export default AdvancedCalendar;