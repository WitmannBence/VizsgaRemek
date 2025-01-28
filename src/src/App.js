// src/App.js
import React from 'react';
import './App.css';
import { Route, Routes } from 'react-router-dom';
import Home from './Home';
import RegistrationPage from './RegistrationPage';

const App = () => {

   return (
    <div>
        <Routes>
            <Route path='/' element={<Home/>}/>
            <Route path='/registration' element={<RegistrationPage/>}/>
        </Routes>
    </div>
   )
};

export default App;
