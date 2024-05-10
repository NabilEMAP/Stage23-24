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
  const [showNewModal, setShowNewModal] = useState(false);
  const [selectedDay, setSelectedDay] = useState(null);

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

  const handleDayClick = (date) => {
    setSelectedDay(date);
    setShowNewModal(true); // Open the modal when a day is clicked
  };

  const handleCloseModal = () => {
    setShowCurrentModal(false);
    setShowNewModal(false);
  };

  const handleAddEvent = () => {
    // Here you can handle adding the event for the selected day
    console.log("Adding event for:", selectedDay);
    // You can handle further actions like submitting data to the server or updating state
    handleCloseModal(); // Close the modal after adding the event
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
        onSelectSlot={handleDayClick}
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
      <Modal show={showNewModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Add Event</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>Add event for</p>
          
        </Modal.Body>
        <Modal.Footer>
          <button onClick={handleCloseModal}>Cancel</button>
          <button onClick={handleAddEvent} variant="contained" color="primary">Add Event</button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
export default AdvancedCalendar;