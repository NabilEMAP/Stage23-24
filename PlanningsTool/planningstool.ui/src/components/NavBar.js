import {
    AppBar,
    Toolbar,
    IconButton,
    Typography,
    Button,
    Stack,
    Menu,
    MenuItem
} from '@mui/material'
import EditCalendarIcon from '@mui/icons-material/EditCalendar';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown'
import SettingsIcon from '@mui/icons-material/Settings';
import { useState } from 'react'
import MyTitle from './MyTitle';

export const NavBar = () => {
    const [anchorEl, setAnchorEl] = useState(null)
    const open = Boolean(anchorEl)
    const handleClick = (event) => {
        setAnchorEl(event.currentTarget)
    }
    const handleClose = () => {
        setAnchorEl(null)
    }
    return (
        <AppBar position='static' color='transparent'>
            <Toolbar>
                <IconButton href='/' size='large' edge='start' color='inherit' aria-label='logo'>
                    <EditCalendarIcon style={{ color: "#d10202" }} />
                </IconButton>
                <Typography variant='h6' component='div' sx={{ flexGrow: 1 }}>
                    <a href='/' style={{ textDecoration: "none", color: "inherit" }}>
                        <MyTitle />
                    </a>
                </Typography>
                <Stack direction='row' spacing={2}>
                    <Button id="navPlanning" href='/teamplanning' color='inherit'>Planning</Button>
                    <Button id="navTeam" href='/team' color='inherit'>Teams</Button>
                    <Button id="navVacation" href='/verlof' color='inherit'>Verlof</Button>
                    <Button id="navNurseShift" href='/shift' color='inherit'>Shift</Button>
                    <Button
                        color='inherit'
                        id='types-button'
                        aria-controls={open ? 'types-menu' : undefined}
                        aria-haspopup='true'
                        aria-expanded={open ? 'true' : undefined}
                        endIcon={<KeyboardArrowDownIcon />}
                        onClick={handleClick}>
                        <SettingsIcon />
                    </Button>
                </Stack>
                <Menu
                    id='types-menu'
                    anchorEl={anchorEl}
                    open={open}
                    onClose={handleClose}
                    anchorOrigin={{
                        vertical: 'bottom',
                        horizontal: 'right'
                    }}
                    transformOrigin={{
                        vertical: 'top',
                        horizontal: 'right'
                    }}
                    MenuListProps={{
                        'aria-labelledby': 'types-button'
                    }}>
                    <MenuItem id="navRegimeType" onClick={handleClose}><Button href='/regimetype' color='inherit'>Regime Type</Button></MenuItem>
                    <MenuItem id="navVacationType" onClick={handleClose}><Button href='/verloftype' color='inherit'>Verlof Type</Button></MenuItem>
                    <MenuItem id="navShiftType" onClick={handleClose}><Button href='/shifttype' color='inherit'>Shift Type</Button></MenuItem>
                    <MenuItem id="navHoliday" onClick={handleClose}><Button href='/feestdag' color='inherit'>Feestdag</Button></MenuItem>
                </Menu>
            </Toolbar>
        </AppBar>
    )
}