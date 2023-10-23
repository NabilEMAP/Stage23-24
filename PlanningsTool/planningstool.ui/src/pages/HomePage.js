import React, { Fragment } from "react";
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import CssBaseline from '@mui/material/CssBaseline';
import Grid from '@mui/material/Grid';
import Stack from '@mui/material/Stack';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import Link from '@mui/material/Link';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { homecards } from "../constants";

function Copyright() {
    return (
        <Typography variant="body2" color="text.secondary" align="center">
            {'Copyright © '}
            <Link color="inherit" href="https://github.com/NabilEMAP/Stage23-24/">
                Nabil El Moussaoui
            </Link>{' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

// TODO remove, this demo shouldn't need to reset the theme.
const defaultTheme = createTheme();

function HomePage() {
    return (
        <Fragment>
            <ThemeProvider theme={defaultTheme}>
                <CssBaseline />
                <main>
                    {/* Hero unit */}
                    <Box
                        sx={{
                            bgcolor: 'background.paper',
                            pt: 8,
                            pb: 6,
                        }}
                    >
                        <Container maxWidth="sm">
                            <Typography
                                component="h1"
                                variant="h2"
                                align="center"
                                color="text.primary"
                                gutterBottom
                            >
                                Planningstool <span style={{ color: "#d10202" }}>voor</span> Ziekenhuisdienst
                            </Typography>
                            <Typography variant="h5" align="center" color="text.secondary" paragraph>
                            Een planningstool is een softwaretoepassing of digitale tool die is ontworpen om de zorgkundigen hun activiteiten in te plannen. 
                            </Typography>
                            <Stack
                                sx={{ pt: 4 }}
                                direction="row"
                                spacing={2}
                                justifyContent="center"
                            >
                                <Button href="/teamplanning" variant="contained" color="error">Maak een teamplanning</Button>
                                
                            </Stack>
                        </Container>
                    </Box>
                    <Container sx={{ py: 8 }} maxWidth="md">
                        {/* End hero unit */}
                        <Grid container spacing={4}>
                            {homecards.map((homecard, index) => (
                                <Grid item key={homecard} xs={12} sm={6} md={4}>
                                    <Card
                                        sx={{ height: '100%', display: 'flex', flexDirection: 'column' }}
                                    >
                                        <CardMedia
                                            component="div"
                                            sx={{
                                                // 16:9
                                                pt: '56.25%',
                                            }}
                                            image={homecard.image}
                                        />
                                        <CardContent sx={{ flexGrow: 1 }}>
                                            <Typography gutterBottom variant="h5" component="h2">
                                                {homecard.heading}
                                            </Typography>
                                            <Typography>
                                                {homecard.description}
                                            </Typography>
                                        </CardContent>
                                    </Card>
                                </Grid>
                                        ))}
                        </Grid>
                    </Container>
                </main>
                {/* Footer */}
                <Box sx={{ bgcolor: 'background.paper', p: 6 }} component="footer">
                    <Typography variant="h6" align="center" gutterBottom>
                        Footer
                    </Typography>
                    <Typography
                        variant="subtitle1"
                        align="center"
                        color="text.secondary"
                        component="p"
                    >
                        Something here to give the footer a purpose!
                    </Typography>
                    <Copyright />
                </Box>
                {/* End footer */}
            </ThemeProvider>
        </Fragment>
    );
}
export default HomePage;