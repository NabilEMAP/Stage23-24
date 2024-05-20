import moment from "moment";
import Calendar from "../Calendar";
import React, { useEffect, useState } from "react";
import { API_BASE_URL } from "../../config";
import axios from "axios";
import Modal from 'react-bootstrap/Modal';
import { Button, FormControl, InputLabel, MenuItem, Select, Stack, TextField } from "@mui/material";
import AddVacation from '../vacations/AddVacation';
import EditVacation from '../vacations/EditVacation';
import DeleteVacation from '../vacations/DeleteVacation';
import AddNurseShift from '../nurseShifts/AddNurseShift';
import EditNurseShift from '../nurseShifts/EditNurseShift';
import DeleteNurseShift from '../nurseShifts/DeleteNurseShift';
import AddHoliday from '../holidays/AddHoliday';
import EditHoliday from '../holidays/EditHoliday';
import DeleteHoliday from '../holidays/DeleteHoliday';
import { toast } from 'react-toastify';

function AdvancedCalendar() {
  const [teamplanData, setTeamplanData] = useState([]);
  const [teamplanId, setTeamplanId] = useState('');
  const [teamData, setTeamData] = useState([]);
  const [teamId, setTeamId] = useState('');
  const [vacationData, setVacationData] = useState([]);
  const [nurseShiftData, setNurseShiftData] = useState([]);
  const [holidayData, setHolidayData] = useState([]);
  const [selectedEvent, setSelectedEvent] = useState(null);
  const [showCurrentEvent, setShowCurrentEvent] = useState(false);
  const [selectedDateSlot, setSelectedDateSlot] = useState(null);
  const [showNewEvent, setShowNewEvent] = useState(false);

  useEffect(() => {
    getVacationData();
    getNurseShiftData();
    getHolidayData();
    getTeamplanData();
    getTeamData();
  }, []);

  const handleSlotSelect = (slotInfo) => {
    setSelectedDateSlot(slotInfo);
    setShowNewEvent(true);
  };

  const handleEventSelect = (event) => {
    setSelectedEvent(event);
    setShowCurrentEvent(true);
  };

  const handleCloseModal = () => {
    setShowCurrentEvent(false);
    setShowNewEvent(false);
  };

  const getTeamplanData = () => {
    const API = `${API_BASE_URL}/Teamplans`;
    axios.get(API)
      .then((result) => {
        setTeamplanData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      });
  }

  const getTeamData = () => {
    const API = `${API_BASE_URL}/Teams`;
    axios.get(API)
      .then((result) => {
        setTeamData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      });
  }

  const getVacationData = () => {
    const API = `${API_BASE_URL}/Vacations/details`;
    axios.get(API)
      .then((result) => {
        setVacationData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      });
  };
  const getNurseShiftData = (teamplanId) => {
    const API = `${API_BASE_URL}/NurseShifts?teamplanId=${teamplanId}`;
    axios.get(API)
      .then((result) => {
        setNurseShiftData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      });
  };
  const getHolidayData = () => {
    const API = `${API_BASE_URL}/Holidays`;
    axios.get(API)
      .then((result) => {
        setHolidayData(result.data);
      })
      .catch((error) => {
        toast.warning(error.message + ': ' + API.split('/api/')[1]);
      });
  };
  const formatVacationData = (data) => {
    const filteredVacations = data.filter(vacation => vacation.nurse.teamId === teamId);
    return filteredVacations.map(vacation => ({
      start: moment(vacation.startdate).toDate(),
      end: moment(vacation.enddate).add(1, 'day').toDate(),
      title: `${vacation.nurse.firstName} ${vacation.nurse.lastName} - Team Id: ${vacation.nurse.teamId}`,
      data: {
        type: "Vacation",
        id: vacation.id,
      },
    }));
  };
  const formatNurseShiftData = (data) => {
    const filteredNurseshifts = data.filter(nurseShift => nurseShift.teamplanId === teamplanId);
    return filteredNurseshifts.map(nurseShift => ({
      start: moment(nurseShift.date).add(nurseShift.shift.starttime, 'hours').toDate(),
      end: moment(nurseShift.date).add(nurseShift.shift.endtime, 'hours').toDate(),
      title: `${nurseShift.nurse.firstName} ${nurseShift.nurse.lastName} - Team Id: ${nurseShift.nurse.teamId}`,
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
  const renderTeamplan = () => {
    return teamplanData.map((item) => (
      <MenuItem key={item.id} value={item.id}>{item.name}</MenuItem>
    ));
  };
  const renderTeam = () => {
    return teamData.map((item) => (
      <MenuItem key={item.id} value={item.id}>{item.teamName}</MenuItem>
    ));
  };
  const handleTeamplanChange = (e) => {
    const selectedTeamplanId = e.target.value;
    setTeamplanId(selectedTeamplanId);
    getNurseShiftData(selectedTeamplanId);
  }
  const handleTeamChange = (e) => {
    const selectedTeamId = e.target.value;
    setTeamId(selectedTeamId);
    getVacationData(selectedTeamId);
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
        onSelectSlot={handleSlotSelect}
        selectable
      />
      <Modal show={showCurrentEvent} onSelectUpdate={handleCloseModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Huidige planning</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          {selectedEvent && (
            <>
              <p>{selectedEvent.title}</p>
              {selectedEvent.data.type === "Vacation" && (
                <>
                  <EditVacation
                    id={selectedEvent.data.id}
                    onUpdate={getVacationData}
                    onEditComplete={handleCloseModal}
                  />
                  <DeleteVacation
                    id={selectedEvent.data.id}
                    onUpdate={getVacationData}
                    onDeleteComplete={handleCloseModal}
                  />
                </>
              )}
              {selectedEvent.data.type === "Shift" && (
                <>
                  <EditNurseShift
                    id={selectedEvent.data.id}
                    onUpdate={getNurseShiftData}
                    onEditComplete={handleCloseModal}
                    teamplanId={teamplanId}
                  />
                  <DeleteNurseShift
                    id={selectedEvent.data.id}
                    onUpdate={getNurseShiftData}
                    onDeleteComplete={handleCloseModal}
                  />
                </>
              )}
              {selectedEvent.data.type === "Holiday" && (
                <>
                  <EditHoliday
                    id={selectedEvent.data.id}
                    onUpdate={getHolidayData}
                    onEditComplete={handleCloseModal}
                  />
                  <DeleteHoliday
                    id={selectedEvent.data.id}
                    onUpdate={getHolidayData}
                    onDeleteComplete={handleCloseModal}
                  />
                </>
              )}
            </>
          )}
        </Modal.Body>
      </Modal>
      <Modal show={showNewEvent} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Planning aanmaken</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Stack
            direction="column"
            justifyContent="center"
            alignItems="center"
            spacing={4}
            style={{ height: '250px' }}
          >
            <p>Selected Slot: {selectedDateSlot && selectedDateSlot.start.toLocaleDateString()}</p>
            <FormControl style={{ width: '75%' }}>
              <AddVacation
                onUpdate={getVacationData}
                onAddComplete={handleCloseModal}
                selectedDateSlot={selectedDateSlot}
              />
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <AddNurseShift
                onUpdate={getNurseShiftData}
                onAddComplete={handleCloseModal}
                selectedDateSlot={selectedDateSlot}
                teamplanId={teamplanId}
              />
            </FormControl>
            <FormControl style={{ width: '75%' }}>
              <AddHoliday
                onUpdate={getHolidayData}
                onAddComplete={handleCloseModal}
                selectedDateSlot={selectedDateSlot}
              />
            </FormControl>
          </Stack>
        </Modal.Body>
      </Modal>
      <Stack
            direction="row"
            justifyContent="center"
            alignItems="center"
            spacing={4}
          >
        <FormControl style={{ width: '75%' }}>
          <InputLabel>Teams *</InputLabel>
          <Select
            required
            id="selectTeam"
            label="Team"
            value={teamId}
            onChange={handleTeamChange}
          >
            {renderTeam()}
          </Select>
        </FormControl>
        <FormControl style={{ width: '75%' }}>
          <InputLabel>Teamplanningen *</InputLabel>
          <Select
            required
            id="selectTeamplan"
            label="Teamplan"
            value={teamplanId}
            onChange={handleTeamplanChange}
          >
            {renderTeamplan()}
          </Select>
        </FormControl>
      </Stack>
    </>
  );
}
export default AdvancedCalendar;