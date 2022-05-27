// Material Design Imports
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';


// using custom environment variables
const { REACT_APP_TITLE } = process.env

const Header = ({ title }) => {

    return (
        <header>
            <Box sx={{ flexGrow: 1 }}>
                <AppBar position="static">
                    <Toolbar variant="dense">
                        <Typography
                            variant="h6"
                            noWrap
                            component="div"
                            // sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' } }}
                        >
                            {title}
                        </Typography>
                    </Toolbar>
                </AppBar>
            </Box>
        </header>
    )
}


// // prop defaults
Header.defaultProps = {
    title: `${REACT_APP_TITLE}`
}

export default Header