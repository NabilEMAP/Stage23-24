import {
    zorgkundige,
    verlof,
    shift,
    zorgkundigeshift,
} from "../assets"

const homecards = [
    {
        heading: "Zorgkundige",
        description: "Lijst van zorgkundigen",
        url: "/zorgkundige",
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
        image: shift,
    },
    {
        heading: "Zorgkundige Shift",
        description: "Lijst van zorgkundigen met een shift",
        url: "/shift",
        image: zorgkundigeshift,
    },
];
export { homecards }