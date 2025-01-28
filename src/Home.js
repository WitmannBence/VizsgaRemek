import React from 'react';
import { Link } from 'react-router-dom';

const Home = () => {

    return (
        <div className="container">
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
                    <Link to="/LoginPage">
                        <button className="cta-button">
                            Bejelentkezés
                        </button>
                    </Link>
                    <Link to="/RegistrationPage">
                    <button className="cta-button">
                        Regisztrálok
                    </button>
                    </Link>
                </div>
        </div>
    );
};

export default Home;
