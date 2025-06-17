function MovieCard({ movie }) {
  return <div className="movie-card">
    <div className="movie-poster">
      <img src={movie.coverLink} alt={movie.title} />
    </div>
    <div className="movie-info">
      <h3>{movie.title} ({movie.releaseYear})</h3>
      <h5>{movie.duration}</h5>
      <p>{movie.whoChose}</p>
    </div>
  </div>
}

export default MovieCard;
