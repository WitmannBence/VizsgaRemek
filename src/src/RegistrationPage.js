// src/RegistrationPage.js
import React from 'react';

const RegistrationPage = ({ setShowRegistration }) => {
    return (
        <section className="auth-form">
            <h2>Regisztráció</h2>
            <input type="text" placeholder="Felhasználónév" />
            <input type="email" placeholder="Email" />
            <input type="password" placeholder="Jelszó" />
            <button className="form-button">Regisztráció</button>
            <p>Már van fiókod? <a href="#">Elfelejtett jelszó</a></p>
            {/* Button to go back to home */}
            <button 
                className="cta-button" 
                onClick={() => setShowRegistration(false)}
            >
                Vissza a kezdőlapra
            </button>
        </section>
    );
};

export default RegistrationPage;
