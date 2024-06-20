// Файл: src/App.js

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './components/HomePage/HomePage';
import AdminPanel from './components/AdminPanel/AdminPanel';
import Navbar from './components/Navbar/Navbar';
import './App.css';

const App = () => {
    return (
        <Router>
            <div>
                <Navbar />
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/admin" element={<AdminPanel />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
