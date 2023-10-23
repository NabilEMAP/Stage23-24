import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ZorgkundigePage from '../pages/ZorgkundigePage';
import HomePage from '../pages/HomePage';
import TeamplanningPage from '../pages/TeamplanningPage';
import ZorgkundigeShiftPage from '../pages/ZorgkundigeShiftPage';
import VerlofPage from '../pages/VerlofPage';
import ShiftPage from '../pages/ShiftPage';
import RegimeTypePage from '../pages/types/RegimeTypePage';
import VerlofTypePage from '../pages/types/VerlofTypePage';
import ShiftTypePage from '../pages/types/ShiftTypePage';

export default function Routing() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/teamplanning" element={<TeamplanningPage />} />
                <Route path="/zorgkundige" element={<ZorgkundigePage />} />
                <Route path="/zorgkundigeshift" element={<ZorgkundigeShiftPage/>} />
                <Route path="/verlof" element={<VerlofPage />} />
                <Route path="/shift" element={<ShiftPage />} />
                <Route path="/regimetype" element={<RegimeTypePage/>} />
                <Route path="/verloftype" element={<VerlofTypePage/>} />
                <Route path="/shifttype" element={<ShiftTypePage/>} />
            </Routes>
        </BrowserRouter>
    );
}