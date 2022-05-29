import './App.css';

// Material Design Imports
import Box from '@mui/material/Box';

// Header
import Header from './components/Header'
// Movies
import ListMovies from './components/ListMovies'
// Footer
import Footer from './components/Footer'

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
        </>
    )
}

export default App;
