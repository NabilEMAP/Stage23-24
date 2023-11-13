import { BrowserRouter, Routes, Route } from 'react-router-dom';
import NursePage from '../pages/NursePage';
import HomePage from '../pages/HomePage';
import TeamplanPage from '../pages/TeamplanPage';
import NurseShiftPage from '../pages/NurseShiftPage';
import VacationPage from '../pages/VacationPage';
import ShiftPage from '../pages/ShiftPage';
import RegimeTypePage from '../pages/overige/RegimeTypePage';
import VacationTypePage from '../pages/overige/VerlofTypePage';
import ShiftTypePage from '../pages/overige/ShiftTypePage';
import HolidayPage from '../pages/overige/HolidayPage';

export default function Routing() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/teamplanning" element={<TeamplanPage />} />
                <Route path="/zorgkundige" element={<NursePage />} />
                <Route path="/shift" element={<NurseShiftPage/>} />
                <Route path="/verlof" element={<VacationPage />} />
                <Route path="/regimetype" element={<RegimeTypePage/>} />
                <Route path="/verloftype" element={<VacationTypePage/>} />
                <Route path="/shifttype" element={<ShiftTypePage/>} />
                <Route path="/feestdag" element={<HolidayPage/>} />
            </Routes>
        </BrowserRouter>
    );
}