import { useParams } from 'react-router-dom';
import '../css/MovieForm.css'
import { useState, useEffect } from "react";
import { createMovie, getMovieById, updateMovie } from '../services/api';

function MovieForm() {
  const { id } = useParams();
  const isEdit = !!id;

  const [form, setForm] = useState({
    title: '',
    coverLink: '',
    whoChose: '',
    rating: 0,
    duration: 0,
    releaseYear: 1900,
    watched: false,
    summary: '',
  });

  useEffect(() => {
    if (isEdit) {
      const fetchMovie = async () => {
        const data = await getMovieById(id);
        setForm({
          title: data.title || '',
          coverLink: data.coverLink || '',
          whoChose: data.whoChose || '',
          rating: data.rating || 0,
          duration: data.duration || 0,
          releaseYear: data.releaseYear || 1900,
          watched: data.watched || false,
          summary: data.summary || '',
        });
      };
      fetchMovie();
    }
  }, [id, isEdit]);
  const handleReset = () => {
    setForm({
      title: '',
      coverLink: '',
      whoChose: '',
      rating: '',
      duration: '',
      releaseYear: '1900',
      watched: false,
      summary: '',
    });
  };

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setForm((prev) => ({
      ...prev,
      [name]: type === 'checkbox' ? checked : value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const movieData = {
      ...form,
      rating: parseFloat(form.rating),
      duration: parseInt(form.duration),
      releaseYear: parseInt(form.releaseYear),
    };

    if (isEdit) {
      updateMovie(id, movieData);
    } else {
      createMovie(movieData)
    }

    handleReset();
  }

  return (
    <div className="form-container">
      <h2>{id ? 'Edit Movie' : 'Add Movie'}</h2>
      <form onSubmit={handleSubmit} onReset={handleReset}>
        <div className="form-group">
          <label>Title</label>
          <input
            type="text"
            name="title"
            value={form.title}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label>Cover Link</label>
          <input
            type="text"
            name="coverLink"
            value={form.coverLink}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label>Who Chose</label>
          <input
            type="text"
            name="whoChose"
            value={form.whoChose}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label>Rating</label>
          <input
            type="number"
            step="0.5"
            min="0"
            max="5"
            name="rating"
            value={form.rating}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label>Duration (min)</label>
          <input
            type="number"
            name="duration"
            value={form.duration}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label>Release Year</label>
          <input
            type="number"
            name="releaseYear"
            value={form.releaseYear}
            onChange={handleChange}
            className="form-control"
          />
        </div>

        <div className="form-group">
          <label>Summary</label>
          <textarea
            name="summary"
            value={form.summary}
            onChange={handleChange}
            className="form-control"
            rows="4"
          ></textarea>
        </div>

        <div className="form-group">
          <label>
            <input
              type="checkbox"
              name="watched"
              checked={form.watched}
              onChange={handleChange}
            />{' '}
            Watched
          </label>
        </div>

        <div className="form-actions">
          <button type="submit" className="btn-submit">Save</button>
          <button type="reset" className="btn-reset">Reset</button>
        </div>
      </form>
    </div>
  );
}

export default MovieForm;
