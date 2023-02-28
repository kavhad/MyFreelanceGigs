import {Gig} from "../../../Frontend/.generated";
import {Fragment } from "react";
import "./LeadListView.css";

export default function GigListView({gigList}:{gigList:Gig[] | undefined}) {
    
    return <div>
            {gigList?.map(gig =>
            <Fragment key={gig.id}>
                <h3>{gig.title}</h3>
            </Fragment>
            )}
    </div>
}