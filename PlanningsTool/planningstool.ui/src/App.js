import { LocalizationProvider } from "@mui/x-date-pickers";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import MyToastify from "./components/MyToastify";
import { NavBar } from "./components/NavBar";
import Routing from "./routing/Routing";

function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterDayjs}>
      <div>
        <MyToastify />
        <NavBar />
        <Routing />
      </div>
    </LocalizationProvider>
  );
}

export default App;
