import React from 'react';

const RegistrationPage = () => {
    return (
        <section className="auth-form">
            <h2>Regisztráció</h2>
            <input type="text" placeholder="Felhasználónév" />
            <input type="email" placeholder="Email" />
            <input type="password" placeholder="Jelszó" />
            <button className="form-button">Regisztráció</button>
            <p>Már van fiókod? <a href="#">Elfelejtett jelszó</a></p>
        </section>
    );
};

export default RegistrationPage;
