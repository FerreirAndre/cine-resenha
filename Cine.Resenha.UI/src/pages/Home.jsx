import { useState, useEffect } from "react";
import '../css/Home.css'
import MovieCard from "../components/MovieCard"
import { deleteMovie, getAllMovies, updateWatched } from "../services/api"

function Home() {
  const [movies, setMovies] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);


  const loadAllMovies = async () => {
    try {
      const allMovies = await getAllMovies();
      console.log("loaded movies: ", allMovies);
      setMovies(allMovies);
    }
    catch (err) {
      console.log(err);
      setError("failed to load movies.");
    }
    finally {
      setLoading(false);
    }
  }

  const toggleWatched = async (id) => {
    try {
      await updateWatched(id);
      loadAllMovies();
    } catch (err) {
      console.log(err);
      setError(err);
    }
  }

  const onDeleteMovie = async (id) => {
    try {
      await deleteMovie(id);
      loadAllMovies();
    } catch (err) {
      console.log(err);
      setError(err);
    }
  }

  useEffect(() => {
    loadAllMovies();
  }, []);

  return <div className="home">
    {error && <div className="error-message">{error}</div>}
    {loading ?
      <div className="loading">Loading...</div>
      :
      <div className="movies-grid">
        {movies.map(movie => <MovieCard movie={movie} key={movie.id} onToggleWatched={toggleWatched} onDeleteMovie={onDeleteMovie} />)}
      </div>
    }
  </div>
}

export default Home;
