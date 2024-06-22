import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AdminPanel from './components/AdminPanel/AdminPanel';
import HomePage from './components/HomePage/HomePage'
import Navbar from './components/Navbar/Navbar'
import UserManagement from './components/users/UserManagement';
import ProductManagement from './components/Products/ProductManagement';


const App = () => {
    return (
        <Router>
            <div>
            <Navbar />
            <Routes>
                <Route path="/" element={<HomePage />} />   
                <Route path="/admin" element={<AdminPanel />}>
                    <Route path="users" element={<UserManagement />} />
                    <Route path="products" element={<ProductManagement />} />
                </Route>
            </Routes>
            </div>
        </Router>
    );
};

export default App;
