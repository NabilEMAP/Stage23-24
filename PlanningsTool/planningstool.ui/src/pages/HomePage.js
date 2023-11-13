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
import { homecards } from "../constants";
import MyTitle from "../components/MyTitle";

function Copyright() {
    return (
        <Typography variant="body2" color="text.secondary" align="center">
            {'Copyright © '}
            <Link color="inherit" href="https://github.com/NabilEMAP/Stage23-24/">
                Nabil El Moussaoui
            </Link>
            {' 2023 - 2024.'}
        </Typography>
    );
}

function HomePage() {
    return (
        <Fragment>
            <CssBaseline />
            <main>
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
                            <MyTitle />
                        </Typography>
                        <Typography variant="h5" align="center" color="text.secondary" paragraph>
                            Een planningstool is een softwaretoepassing of digitale tool die ontworpen is om de zorgkundigen hun activiteiten in te plannen.
                        </Typography>
                        <Stack
                            sx={{ pt: 4 }}
                            direction="row"
                            spacing={2}
                            justifyContent="center"
                        >
                            <Button href="/teamplanning" variant="contained" color="error">Maak een teamplanning</Button>
                            {/*<Button href="/over" variant="outlined" color="error">Over</Button>*/}
                        </Stack>
                    </Container>
                </Box>
                <Container sx={{ py: 8 }} maxWidth="md">
                    <Grid container spacing={4}>
                        {homecards.map((homecard) => (
                            <Grid item key={homecard} xs={12} sm={4} md={4}>
                                <a href={homecard.url} style={{ textDecoration: "none" }}>
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
                                        </CardContent>
                                    </Card>
                                </a>
                            </Grid>
                        ))}
                    </Grid>
                </Container>
            </main>
            <Box sx={{ bgcolor: 'background.paper', p: 6 }} component="footer">
                <Copyright />
            </Box>
        </Fragment>
    );
}
export default HomePage;