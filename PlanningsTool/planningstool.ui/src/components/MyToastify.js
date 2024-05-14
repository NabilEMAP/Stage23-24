import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function MyToastify(slide) {
    return (
        <ToastContainer
            position="bottom-center"
            autoClose={6000}
            hideProgressBar={true}
            newestOnTop={false}
            closeOnClick
            rtl={false}
            pauseOnFocusLoss
            draggable
            pauseOnHover
            theme="colored"
        />
    )
}
export default MyToastify;