import React, { useState, useEffect } from 'react';
import './Users.css';

const UpdateUser = ({ onUpdateUser, users }) => {
    const [userId, setUserId] = useState('');
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [profileImage, setProfileImage] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        const user = {
            id: userId,
            name,
            email,
            login,
            password,
            profileImage,
        };
        onUpdateUser(user);
        setUserId('');
        setName('');
        setEmail('');
        setLogin('');
        setPassword('');
        setProfileImage('');
    };

    return (
        <div className="user-form">
            <h3>Update User</h3>
            <input
                type="text"
                value={userId}
                onChange={(e) => setUserId(e.target.value)}
                placeholder="User ID"
                required
            />
            <input
                type="text"
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Name"
                required
            />
            <input
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Email"
                required
            />
            <input
                type="text"
                value={login}
                onChange={(e) => setLogin(e.target.value)}
                placeholder="Login"
                required
            />
            <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
                required
            />
            <input
                type="text"
                value={profileImage}
                onChange={(e) => setProfileImage(e.target.value)}
                placeholder="Profile Image URL"
            />
            <button onClick={handleSubmit}>Update</button>
        </div>
    );
};


export default UpdateUser;
