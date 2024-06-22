import React from 'react';
import { Link, NavLink, Outlet } from 'react-router-dom';
import './AdminPanel.css'; 

const AdminPanel = () => {
    return (
        <div className="admin-panel">
            <div className="sidebar">
                <ul className="sidebar-links">
                    <li>
                        <NavLink
                            to="/admin/users"
                            className={({ isActive }) => (isActive ? 'active' : '')}
                            >
                            Users
                        </NavLink>
                    </li>
                    <li>
                        <NavLink
                            to="/admin/products"
                            className={({ isActive }) => (isActive ? 'active' : '')}
                        >
                            Products
                        </NavLink>
                    </li>
                </ul>
            </div>
            <div className="admin-content">
                <Outlet />
            </div>
        </div>
    );
};

export default AdminPanel;
