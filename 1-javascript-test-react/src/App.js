// import logo from './logo.svg'; // DELETE THE FILE AS WELL
import './App.css';

import { useState, useEffect } from 'react';
import axios from 'axios'

// Material Design Imports
import Box from '@mui/material/Box';
import { styled, alpha } from '@mui/material/styles';
import InputBase from '@mui/material/InputBase';

// Header
import Header from './components/Header'
// Movies
import ListMovies from './components/ListMovies'
// Footer
import Footer from './components/Footer'


// using custom environment variables
const { REACT_APP_TITLE, REACT_APP_OMDB_API } = process.env

function App() {
    return (
        <>
            <Header />

            <Box
                className="root-content"
                mt={4}
            >
                <ListMovies />
            </Box>

            <Footer />


            {/* <header className="App-header">
            <img src={logo} className="App-logo" alt="logo" />
            <p>
                Edit <code>src/App.js</code> and save to reload.
            </p>
            <a
                className="App-link"
                href="https://reactjs.org"
                target="_blank"
                rel="noopener noreferrer"
            >
                Learn React
            </a>
            </header> */}
        </>
    )
}

export default App;
