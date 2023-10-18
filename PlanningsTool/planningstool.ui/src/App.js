import MyToastify from "./components/MyToastify";
import { NavBar } from "./components/NavBar";
import Routing from "./routing/Routing";

function App() {
  return (
    <div>
      <MyToastify/>
      <NavBar />
      <Routing />
    </div>
  );
}

export default App;
