import React from 'react';
import { Link, useNavigate } from 'react-router-dom';

export default function Navbar() {
    const token = localStorage.getItem("token");
    const username = localStorage.getItem("username");
    const navigate = useNavigate();
    console.log(token);

    const handleLogout = () => {
        // Handle logout by clearing localStorage and redirecting
        localStorage.removeItem("token");
        localStorage.removeItem("username");
        // Add your navigation logic, e.g., redirect to home or login
        navigate("/");
    };

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <a className="navbar-brand" href="#">Navbar</a>
            <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>

            <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav mr-auto">
                    <li className="nav-item">
                        <Link to="/" className="nav-link">Home <span className="sr-only"></span></Link>
                    </li>
                </ul>

                {/* This ul will be right-aligned */}
                <ul className="navbar-nav" style={{ marginLeft: "auto", textAlign: "right" }}>
                    {username && (
                        <li className="nav-item username-item" style={{ marginRight: "20px" }}>
                            <a className="nav-link">Szia, {username}!</a>
                        </li>
                    )}

                    {/* Conditional rendering for the logout button */}
                    {token && (
                        <li className="nav-item logout-item">
                            <button className="nav-link" onClick={handleLogout}>Logout</button>
                        </li>
                    )}
                </ul>
            </div>
        </nav>
    );
}
