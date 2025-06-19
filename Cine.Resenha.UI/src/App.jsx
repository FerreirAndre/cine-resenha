import { Routes, Route } from 'react-router-dom'
import './css/App.css'
import Home from './pages/Home'
import NavBar from './components/NavBar'
import MovieForm from './pages/MovieForm'
import { createMovie } from './services/api'

function App() {
  return (
    <div>
      <NavBar />
      <main className='main-content'>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/create" element={<MovieForm onSubmit={createMovie} />} />
          <Route path='/update/:id' element={<MovieForm />} />
        </Routes>
      </main>
    </div >
  )
}

export default App
