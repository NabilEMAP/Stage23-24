import {
    zorgkundige,
    verlof,
    zorgkundigeshift,
} from "../assets"

const homecards = [
    {
        heading: "Teams",
        description: "Lijst van teams",
        url: "/team",
        image: zorgkundige,
    },
    {
        heading: "Verlof",
        description: "Lijst van verlofdagen",
        url: "/verlof",
        image: verlof,
    },
    {
        heading: "Shift",
        description: "Lijst van shifts",
        url: "/shift",
        image: zorgkundigeshift,
    },
];
export { homecards }