import '../css/NavBar.css'
import { Link } from "react-router-dom";

function NavBar() {
  return <nav className="navbar-brand">
    <Link to="/" className="nav-link">HOME</Link>
    <Link to="/create" className="nav-link">CREATE</Link>
  </nav>
}

export default NavBar;
