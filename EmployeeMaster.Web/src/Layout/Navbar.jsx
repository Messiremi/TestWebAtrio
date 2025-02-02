import { NavLink } from "react-router-dom";

export default function Navbar() {
  return (
	<nav className="navbar">
		<div className="navlinks">
			<NavLink to="/" className="navlink">Home</NavLink>
			<NavLink to="/employees" className="navlink">Manage employees</NavLink>
			<NavLink to="/employments" className="navlink">Manage employments</NavLink>
		</div>
	</nav>
  );
};