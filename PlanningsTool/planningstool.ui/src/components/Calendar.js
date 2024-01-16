import {
    Calendar as BigCalendar,
    CalendarProps,
    momentLocalizer,
} from 'react-big-calendar';
import moment from 'moment';
import 'moment/locale/nl-be';

const localizer = momentLocalizer(moment);

export default function Calendar(props) {
    return <BigCalendar
        {...props}
        localizer={localizer}
        formats={{
            dayHeaderFormat: (date) => moment(date).format("dddd D MMMM"),
            agendaDateFormat: (date) => moment(date).format("dd D MMM"),
            agendaHeaderFormat: ({ start, end }) => {
                return (moment(start).format('dd D MMMM yyyy') + ' - ' + moment(end).format('dd D MMMM yyyy'));
            },
            dateFormat: (date) => moment(date).format("D"),
            dayFormat: (date) => moment(date).format("dd D"),
            dayRangeHeaderFormat: ({ start, end }) => {
                return (moment(start).format('dd D MMMM') + ' - ' + moment(end).format('dd D MMMM'));
            },
            weekdayFormat: (date) => moment(date).format("dddd")
        }}
        messages={{
            date: 'Datum',
            time: 'Tijd',
            event: 'Gebeurtenis',
            allDay: 'De hele dag',
            week: 'Week',
            work_week: 'Werkweek',
            day: 'Dag',
            month: 'Maand',
            previous: 'Vorige',
            next: 'Volgende',
            yesterday: 'Gisteren',
            tomorrow: 'Morgen',
            today: 'Vandaag',
            agenda: 'Agenda',

            noEventsInRange: 'Er zijn geen gebeurtenissen in dit bereik.',

            showMore: total => `+${total} meer`,
        }}
    />;
}