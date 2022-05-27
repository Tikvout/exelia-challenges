import { useState, useEffect } from 'react';

import { styled, alpha } from '@mui/material/styles';
import Grid from '@mui/material/Grid';
import Container from '@mui/material/Container';
import InputBase from '@mui/material/InputBase';
import SearchIcon from '@mui/icons-material/Search';
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import Skeleton from '@mui/material/Skeleton';

const { REACT_APP_OMDB_API } = process.env

// custom styling
const Search = styled('div')(({ theme }) => ({
    position: 'relative',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: alpha(theme.palette.common.black, 0.15),
    '&:hover': {
        backgroundColor: alpha(theme.palette.common.black, 0.25),
    },
    marginRight: theme.spacing(2),
    marginLeft: 0,
    width: '100%',
}))

// custom styling
const SearchIconWrapper = styled('div')(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}))

// custom styling
const StyledInputBase = styled(InputBase)(({ theme }) => ({
    color: 'inherit',
    width: '100%',
    '& .MuiInputBase-input': {
        padding: theme.spacing(1, 1, 1, 0),
        // vertical padding + font size from searchIcon
        paddingLeft: `calc(1em + ${theme.spacing(4)})`
    }
}))

// custom styling
const StyledMovieCard = styled(Card)(() => ({
    position: 'relative',
}))

// custom styling
const StyledMovieContent = styled('div')(() => ({
    position: 'absolute',
    bottom: '15px',
    left: '15px',
    '& .MuiTypography-root': {
        color: '#fff'
    },
}))

function MoviesList () {

    const [searchTerm, setSearchTerm] = useState('') // the term that will be used to search for the movies
    const [movies, setMovies] = useState([]) // the movies to list
    const [isLoading, setIsLoading] = useState(false) // check if the results are being fetched
    const [noResult, setNoResult] = useState(false) // to check if any results were found

    // set a timeout on the user typing
    useEffect(() => {
        const delayDebounceFn = setTimeout(() => {
            // search for movies using axios
            if(searchTerm) {
                // setMovies([])
                fetch_movies()
            } else {
                setIsLoading(false)
                setMovies([])
            }
        }, 500)
        return () => clearTimeout(delayDebounceFn)
    }, [searchTerm])

    // updates the search term
    const updateSearch = (event) => {
        setIsLoading(true)
        setSearchTerm(event.target.value)
    }

    // fetches the movies
    function fetch_movies() {
        fetch(`http://www.omdbapi.com/?s=${searchTerm}&apikey=${REACT_APP_OMDB_API}`)
        .then(response => response.json())
        .then(results => {

            if(results.Response === 'True') {
                // movies found
                setNoResult(false)
                setMovies(results.Search.slice(0, 3))
                setIsLoading(false)
            } else {
                // no results
                setNoResult(true)
                setIsLoading(false)
            }
        })
    }

    return (
        <>
            <Container maxWidth="md">
                <Search>
                    <SearchIconWrapper>
                        <SearchIcon />
                    </SearchIconWrapper>

                    <StyledInputBase
                        placeholder="Search a Movie"
                        inputProps={{ 'aria-label': 'search a movie' }}
                        onChange={updateSearch}
                    />
                </Search>
                <Grid container spacing={2} mt={2}>
                    {isLoading ? (
                        [...Array(3)].map((x, i) =>
                            <Grid key={i} item xs={4}>
                                <Skeleton variant="rectangular" width={274} height={400} />
                            </Grid>
                        )
                    ) : (
                        noResult ? (
                            <Grid item xs={12}>
                                <Typography gutterBottom variant="h5" component="div">
                                    No Result
                                </Typography>
                            </Grid>
                        ) : (
                            movies.map((movie, i) => (
                                <Grid key={i} item xs={4}>
                                    <a
                                        href={`http://www.omdbapi.com/?i=${movie.imdbID}&apikey=${REACT_APP_OMDB_API}`}
                                        target="_blank"
                                    >
                                        <StyledMovieCard
                                            key={i}
                                            sx={{ maxWidth: 300 }}
                                        >
                                            <CardMedia
                                                component="img"
                                                height="400"
                                                // image={movie.Poster}
                                                image={movie.Poster != 'N/A'? movie.Poster : 'https://dummyimage.com/300x445/333/aaa' }
                                                alt={movie.Title}
                                            />
                                            <StyledMovieContent>
                                                <Typography gutterBottom variant="h5" component="div">
                                                    {movie.Title}
                                                </Typography>
                                                <Typography variant="body2" color="text.secondary">
                                                    {movie.Year}
                                                </Typography>
                                            </StyledMovieContent>
                                        </StyledMovieCard>
                                    </a>
                                </Grid>
                            ))
                        )
                    )}
                </Grid>
            </Container>
        </>
    )
}

export default MoviesList