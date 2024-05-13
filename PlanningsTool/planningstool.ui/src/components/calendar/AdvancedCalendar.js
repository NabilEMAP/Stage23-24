import moment from "moment";
import Calendar from "../Calendar";
import React, { useEffect, useState } from "react";
import { API_BASE_URL } from "../../config";
import Modal from 'react-bootstrap/Modal';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";

function AdvancedCalendar() {
  const [showModal, setShowModal] = useState(false);
  const [selectedSlot, setSelectedSlot] = useState(null);

  useEffect(() => {

  }, []);

  const handleSlotSelect = (slotInfo) => {
    setSelectedSlot(slotInfo);
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
    setSelectedSlot(null);
  };
  
  const handleAddEvent = () => {
    console.log("Adding event for slot:", selectedSlot);
    setShowModal(false);
  }

  return (
    <>
      <Calendar
        selectable
        onSelectSlot={handleSlotSelect}
      />
      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Add Event</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <>
            <p>Selected Slot: {selectedSlot && selectedSlot.start.toLocaleString()}</p>
              <Button>Add</Button>
              <Button>Cancel</Button>
            </>
        </Modal.Body>
      </Modal>
    </>
  );
}
export default AdvancedCalendar;