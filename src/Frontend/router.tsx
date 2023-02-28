import React from "react";
import {
    createBrowserRouter,
} from "react-router-dom";

import GigsScene from "../Features/Gigs/Frontend/GigsScene";

const router = createBrowserRouter([
    {
        path: "/",
        element: <GigsScene />
    }
])

export default router;