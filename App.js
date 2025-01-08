// src/App.js
import React, { useState } from 'react';
import RegistrationPage from './RegistrationPage';
import './App.css';

const App = () => {
    const [showRegistration, setShowRegistration] = useState(false);

    return (
        <div className="container">
            {showRegistration ? (
                <RegistrationPage />
            ) : (
                <div className="hero full-screen">
                    <h1>Time Bank</h1>
                    <p>Üdvözlünk a Time Bank weboldalán!</p>
                    <div className="feature-cards">
                        <div className="card">
                            <span>🌐</span>
                            <h3>Kérj segítséget!</h3>
                            <p>Böngéssz felhasználóink által közre tett szolgáltatások közül!</p>
                        </div>
                        <div className="card">
                            <span>⭐</span>
                            <h3>Válaszd ki érdeklődéseidet!</h3>
                            <p>Választhatsz érdeklődési körökből, hogy könnyebben megtaláld amit szeretnél.</p>
                        </div>
                        <div className="card">
                            <span>🔁</span>
                            <h3>Szerezz pontokat!</h3>
                            <p>Minden felhasználó segíthet másoknak, hogy ingyen hozzáférhessenek.</p>
                        </div>
                    </div>
                    <button className="cta-button" onClick={() => setShowRegistration(true)}>
                        Regisztrálok
                    </button>
                </div>
            )}
        </div>
    );
};

export default App;
