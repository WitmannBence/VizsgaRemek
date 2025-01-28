// src/App.js
import React, { useState } from 'react';
import RegistrationPage from './RegistrationPage';
import './App.css';
import { Route, Router, Routes } from 'react-router-dom';
import Home from './Home';
import LoginPage from './LoginPage';

const App = () => {
    
    return (
        <div className="container">
           <Routes>
            <Route path='/' element={<Home/>}/>
            <Route path='/LoginPage' element={<LoginPage/>}/>
            <Route path='/RegistrationPage' element={<RegistrationPage/>}/>
           </Routes>
        </div>
    );
};

export default App;
