import { Routes, Route, BrowserRouter } from "react-router-dom";
import Dashboard from "./Pages/Dashboard";
import App from "./App";


export default function AppRoute() : JSX.Element {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<App />}>
                    <Route index element = {<Dashboard/>} />
                </Route>
            </Routes>
        </BrowserRouter>
    );
}