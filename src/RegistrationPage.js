import React from 'react';
import { Link } from 'react-router-dom';

const RegistrationPage = () => {
    return (
        <section className="hero full-screen">
            <h2>Regisztráció</h2>
            <input type="text" placeholder="Felhasználónév" />
            <br/>
            <input type="email" placeholder="Email" />
            <br/>
            <input type="password" placeholder="Jelszó" />
            <br/>
            <button className="form-button">Regisztráció</button>
            <p>Már van fiókod? <a href="#">Elfelejtett jelszó</a></p>
            <Link to="/">
            <button className="cta-button" >
                Vissza a kezdőlapra
            </button>
            </Link>
        </section>
    );
};

export default RegistrationPage;
