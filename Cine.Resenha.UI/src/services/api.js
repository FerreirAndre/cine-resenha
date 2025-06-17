const API_URL = "http://localhost:5160/api/Movies";

export const getAllMovies = async () => {
  const response = await fetch(`${API_URL}`);
  const data = await response.json();
  return data.results;
};

export const getMovieById = async (id) => {
  const response = await fetch(`${API_URL}/${id}`);
  const data = await response.json();
  return data.results;
};
