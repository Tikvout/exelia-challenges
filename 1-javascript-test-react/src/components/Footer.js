import { styled, alpha } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';

// custom styling
const StyledFooter = styled('div')(({ theme }) => ({
    marginTop: '30px',
    backgroundColor: alpha(theme.palette.common.black, 0.1),
    textAlign: 'center'
}))

const Footer = () => {

    return (
        <StyledFooter>
            <Box sx={{ flexGrow: 1 }}>
                <Container>
                    <Typography
                        component="div"
                        py={1}
                        fontSize={13}
                    >
                        Powered by <a target="_blank" href="https://reactjs.org/">React</a> &amp; built with <a target="_blank" href="https://mui.com/">MUI</a>
                    </Typography>
                </Container>
            </Box>
        </StyledFooter>
    )
}

export default Footer