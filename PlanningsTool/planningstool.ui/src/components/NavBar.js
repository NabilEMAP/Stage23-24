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
import { useState } from 'react'

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
                <IconButton size='large' edge='start' color='inherit' aria-label='logo'>
                    <EditCalendarIcon style={{ color: "#d10202" }} />
                </IconButton>
                <Typography variant='h6' component='div' sx={{ flexGrow: 1 }}>
                    Planningstool <span style={{ color: "#d10202" }}>voor</span> Ziekenhuisdienst
                </Typography>
                <Stack direction='row' spacing={2}>
                    <Button href='/' color='inherit'>Teamplanning</Button>
                    <Button href='/zorgkundige' color='inherit'>Zorgkundige</Button>
                    <Button href='/' color='inherit'>Verlofdag</Button>
                    <Button href='/' color='inherit'>Shift</Button>
                    <Button
                        color='inherit'
                        id='types-button'
                        aria-controls={open ? 'types-menu' : undefined}
                        aria-haspopup='true'
                        aria-expanded={open ? 'true' : undefined}
                        endIcon={<KeyboardArrowDownIcon />}
                        onClick={handleClick}>
                        Types
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
                    <MenuItem onClick={handleClose}><Button href='/' color='inherit'>Regime Type</Button></MenuItem>
                    <MenuItem onClick={handleClose}><Button href='/' color='inherit'>Verlof Type</Button></MenuItem>
                    <MenuItem onClick={handleClose}><Button href='/' color='inherit'>Shift Type</Button></MenuItem>
                </Menu>
            </Toolbar>
        </AppBar>
    )
}