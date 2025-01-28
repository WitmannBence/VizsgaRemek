import React from 'react';
import { Link } from 'react-router-dom';

const LoginPage = () => {
    return (
        <section className="hero full-screen">
            <h2>Bejelentkezés</h2>
            <input type="email" placeholder="Email" />
            <br/>
            <input type="password" placeholder="Jelszó" />
            <br/>
            <button className="form-button">Bejelentkezés</button>
            <p>Még nincs fiókod? 
            <a href="/RegistrationPage">Regisztráció</a></p>
            <Link to="/">
            <button className="cta-button" >
                Vissza a kezdőlapra
            </button>
            </Link>
        </section>
    );
};

export default LoginPage;