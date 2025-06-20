const API_URL = "http://localhost:5160/api/Movies/";

export const getAllMovies = async () => {
  const response = await fetch(API_URL);
  const data = await response.json();
  return data;
};

export const getMovieById = async (id) => {
  const response = await fetch(`${API_URL}${id}`);
  const data = await response.json();
  return data;
};

export const updateWatched = async (id) => {
  await fetch(`${API_URL}${id}/watched`, {
    method: "PATCH",
  })
    .then((res) => {
      if (!res.ok) throw new Error("Erro ao atualizar");
      alert("Status alternado com sucesso!");
    })
    .catch((err) => {
      console.error(err);
      alert("Erro ao alternar status");
    });
};

export const createMovie = async (movie) => {
  await fetch(`${API_URL}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json", // Indicate that the request body is JSON
    },
    body: JSON.stringify(movie),
  })
    .then((res) => {
      if (!res.ok) throw new Error("Erro ao criar filme.");
      alert("Filme criado com sucesso.");
    })
    .catch((err) => {
      console.error(err);
      alert("Erro ao criar filme");
    });
};

export const deleteMovie = async (id) => {
  await fetch(`${API_URL}${id}`, {
    method: "DELETE",
  })
    .then((res) => {
      if (!res.ok) throw new Error("Erro ao deletar filme");
      alert("Filme deletado com sucesso");
    })
    .catch((err) => {
      console.error(err);
      alert("Erro ao deletar filme.");
    });
};

export const updateMovie = async (id, movie) => {
  await fetch(`${API_URL}${id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json", // Indicate that the request body is JSON
    },
    body: JSON.stringify(movie),
  })
    .then((res) => {
      if (!res.ok) throw new Error("Erro ao atualizar filme.");
      alert("Filme atualizado com sucesso.");
    })
    .catch((err) => {
      console.error(err);
      alert("Erro ao atualizar filme");
    });
};
