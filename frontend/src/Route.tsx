import React, { Suspense, lazy } from "react";
import { Routes, Route, BrowserRouter } from "react-router-dom";

const Dashboard = lazy(() => import("./Pages/Dashboard"));
const App = lazy(() => import("./App"));
const Profile = lazy(() => import("./Pages/Profile"));

export default function AppRoute(): JSX.Element {
    return (
        <BrowserRouter>
            <Suspense fallback={<div>Loading...</div>}>
                <Routes>
                    <Route path="/" element={<App />}>
                        <Route index element={<Dashboard />} />
                        <Route path="profile" element={<Profile />} />
                    </Route>
                </Routes>
            </Suspense>
        </BrowserRouter>
    );
}
