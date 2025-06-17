import { useState, useEffect } from "react";
import MovieCard from "../components/MovieCard"
import { getAllMovies } from "../services/api"

function Home() {
  const [movies, setMovies] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadAllMovies = async () => {
      try {
        const allMovies = await getAllMovies();
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
    loadAllMovies();
  }, [])

  return <div className="home">
    {error && <div className="error-message">{error}</div>}
    {loading ? (
      <div className="loading">Loading...</div>
    ) : (
      <div className="movies-grid">
        {movies.map((movie) => <MovieCard movie={movie} />)}
      </div>
    )}
  </div>
}

export default Home;
