import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ZorgkundigePage from '../pages/ZorgkundigePage';

export default function Routing() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/zorgkundige" element={<ZorgkundigePage />} />

                {/*<Route path="/shift-form" element={<ShiftForm/>} />*/}
                {/*<Route path="/verlofdag-form" element={<VerlofdagForm/>} />*/}
                {/*<Route path="/teamplanning-form" element={<TeamplanningForm/>} />*/}

            </Routes>
        </BrowserRouter>
    );
}