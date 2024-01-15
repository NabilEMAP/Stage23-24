import moment from "moment";
import Calendar from "../Calendar";
import "./index.css";

const events = [
  {
    start: moment("2023-12-27T15:20:00").toDate(),
    end: moment("2024-01-05T16:00:00").toDate(),
    title: "UZA Opname - Ontslag",
  },
  {
    start: moment("2023-12-29T16:00:00").toDate(),
    end: moment("2023-12-29T18:00:00").toDate(),
    title: "UZA Medicatie herstructurering",
  },
  {
    start: moment("2024-01-17T08:20:00").toDate(),
    end: moment("2024-01-17T09:20:00").toDate(),
    title: "UZA Bloedafname",
  },
  {
    start: moment("2024-01-17T10:00:00").toDate(),
    end: moment("2024-01-17T11:00:00").toDate(),
    title: "UZA Gastro",
  },
];

export default function CustomizingCalendar() {
  return (
    <Calendar
      events={events}
      formats={{ dayHeaderFormat: (date) => moment(date).format("dddd @ DD") }}
    />
  );
}