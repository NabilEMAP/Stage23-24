import moment from "moment";
import Calendar from "../Calendar";
import React, { useEffect, useState } from "react";
import { API_BASE_URL } from "../../config";
import axios from "axios";
import Modal from 'react-bootstrap/Modal';
import EditVacation from '../vacations/EditVacation'
import DeleteVacation from '../vacations/DeleteVacation'

function AdvancedCalendar() {
  const [vacationData, setVacationData] = useState([]);
  const [selectedEvent, setSelectedEvent] = useState(null);
  const [showCurrentModal, setShowCurrentModal] = useState(false);

  useEffect(() => {
    getVacationData();
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

  const events = [
    ...formatVacationData(vacationData),
  ];

  const handleEventSelect = (event) => {
    setSelectedEvent(event);
    console.log(event.data.id);
    setShowCurrentModal(true); // Open the modal when an event is selected
  };

  const handleCloseModal = () => {
    setShowCurrentModal(false);
  };

  const components = {
    event: (props) => {
      const eventType = props?.event?.data?.type;
      switch (eventType) {
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
      <Modal show={showCurrentModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Selected Event</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {selectedEvent && (
            <>
              <p>{selectedEvent.title}</p>
              <EditVacation id={selectedEvent.data.id} onUpdate={getVacationData} />
              <DeleteVacation id={selectedEvent.data.id} onUpdate={getVacationData} />
            </>
          )}
        </Modal.Body>
      </Modal>
    </>
  );
}
export default AdvancedCalendar;