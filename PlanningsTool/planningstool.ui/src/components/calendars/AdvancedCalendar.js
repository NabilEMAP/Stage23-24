import moment from "moment";
import Calendar from "../Calendar";

const events = [
  {
    start: moment("2023-12-27T15:20:00").toDate(),
    end: moment("2024-01-05T16:00:00").toDate(),
    title: "UZA Opname - Ontslag",
    data: {
      type: "Type1",
    },
  },
  {
    start: moment("2023-12-29T16:00:00").toDate(),
    end: moment("2023-12-29T18:00:00").toDate(),
    title: "UZA Medicatie herstructurering",
    data: {
      type: "Type1",
    },
  },
  {
    start: moment("2024-01-17T08:20:00").toDate(),
    end: moment("2024-01-17T09:20:00").toDate(),
    title: "UZA Bloedafname",
    data: {
      type: "Type2",
    },
  },
  {
    start: moment("2024-01-17T10:00:00").toDate(),
    end: moment("2024-01-17T11:00:00").toDate(),
    title: "UZA Gastro",
    data: {
      type: "Type3",
    },
  },
];

const components = {
  event: (props) => {
    const eventType = props?.event?.data?.type;
    switch (eventType) {
      case "Type1":
        return (
          <div style={{ background: "orange", color: "black", height: "100%" }}>
            {props.title}
          </div>
        );
      case "Type2":
        return (
          <div
            style={{ background: "tomato", color: "black", height: "100%" }}
          >
            {props.title}
          </div>
        );
      case "Type3":
        return (
          <div
            style={{ background: "lightgreen", color: "black", height: "100%" }}
          >
            {props.title}
          </div>
        );
      default:
        return null;
    }
  },
};

export default function AdvancedCalendar() {
  return <Calendar events={events} components={components} />;
}