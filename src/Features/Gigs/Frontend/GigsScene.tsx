import GigListView from "./GigListView";
import React, {useEffect, useState} from "react";
import {GigsAppApiService, Gig} from "../../../Frontend/.generated";
import {Box, Typography, AppBar, Toolbar, IconButton} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";

export default function GigsScene() {
    
    const [gigList, setGigList] = useState<Gig[]>();
    
    useEffect( () => {
        GigsAppApiService
            .getApiV1Gigs()
            .then(res => {
                setGigList(res);
            })
    }, []);
    
    return <><Box sx={{flexGrow: 1}}>
        <AppBar position={"static"}>
            <Toolbar variant={"dense"}>
                <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
                    <MenuIcon />
                </IconButton>
                <Typography variant={"h6"} component={"div"} color={"inherit"}>
                    Gigs
                </Typography>
            </Toolbar>

        </AppBar>
        
    </Box><GigListView gigList={gigList} /></>
}