import '../css/MovieCard.css'
import MovieForm from '../pages/MovieForm';
import { useNavigate } from 'react-router-dom';

function MovieCard({ movie, onToggleWatched, onDeleteMovie }) {
  const navigate = useNavigate();
  const handleEdit = (id) => {
    navigate(`/update/${id}`)
  }

  return <div className="movie-card">
    <div className="movie-poster">
      <img src={movie.coverLink} alt={movie.title} onClickCapture={() => handleEdit(movie.id)} />
      <div className="movie-overlay">
        <button className='watched-btn' onClick={() => onToggleWatched(movie.id)}>{movie.watched ? '👁' : '𓂀 '}</button>
        <button className='delete-btn' onClick={() => onDeleteMovie(movie.id)}>🗑</button>
        <button className='edit-btn' onClick={() => handleEdit(movie.id)}>🖉</button>
      </div>
    </div>
    <div className="movie-info">
      <h3>{movie.title} ({movie.releaseYear})</h3>
      <h4 className='duration'>Duration: {movie.duration} min</h4>
      <p className='who-chose'>{movie.whoChose}</p>
      <p className='user-rating'>Nota: {movie.rating}</p>
    </div>
  </div>
}

export default MovieCard;
