import { BrowserRouter, Routes, Route } from 'react-router-dom';
import NursePage from '../pages/NursePage';
import HomePage from '../pages/HomePage';
import PlanPage from '../pages/PlanPage';
import NurseShiftPage from '../pages/NurseShiftPage';
import VacationPage from '../pages/VacationPage';
import RegimeTypePage from '../pages/overige/RegimeTypePage';
import VacationTypePage from '../pages/overige/VerlofTypePage';
import ShiftTypePage from '../pages/overige/ShiftTypePage';
import HolidayPage from '../pages/overige/HolidayPage';
import TeamPage from '../pages/TeamPage';
import TeamplanPage from '../pages/TeamplanPage';

export default function Routing() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/team" element={<TeamPage />} />
                <Route path="/plan" element={<PlanPage />} />
                <Route path="/team/:teamId" element={<NursePage />} />
                <Route path="/teamplan" element={<TeamplanPage />} />
                <Route path="/teamplan/:teamplanId" element={<NurseShiftPage />} />
                <Route path="/verlof" element={<VacationPage />} />
                <Route path="/regimetype" element={<RegimeTypePage />} />
                <Route path="/verloftype" element={<VacationTypePage />} />
                <Route path="/shifttype" element={<ShiftTypePage />} />
                <Route path="/feestdag" element={<HolidayPage />} />
            </Routes>
        </BrowserRouter>
    );
}