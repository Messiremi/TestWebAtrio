import logo from './logo.svg';
import './App.css';
import Header from './Layout/Header.jsx';
import Navbar from './Layout/Navbar.jsx';
import Footer from './Layout/Footer.jsx';
import Home from './Pages/Home.jsx';
import Employees from './Pages/Employees.jsx';
import Employments from './Pages/Employments.jsx';
import { Routes, Route } from 'react-router-dom';
import './variables.js';

function App() {
  return (
    <div className="app">
		<Header />
		<Navbar />
	  <main className="content">
		<div className="container">
		     <Routes>
				<Route path="/" element={<Home />} />
				<Route path="/employees" element={<Employees />} />
				<Route path="/employments" element={<Employments />} />
			</Routes>
		</div>
	  </main>
    </div>
  );
}

export default App;
