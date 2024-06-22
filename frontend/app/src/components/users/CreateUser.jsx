import React, { useState } from 'react';
import './Users.css';

const CreateUser = ({ onCreateUser }) => {
    const [user, setUser] = useState({
        name: '',
        email: '',
        login: '',
        password: '',
        profileImage: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onCreateUser(user);
        setUser({ name: '', email: '', login: '', password: '', profileImage: '' });
    };

    return (
        <form className="user-form" onSubmit={handleSubmit}>
            <h3>Create User</h3>
            <input type="text" name="name" value={user.name} onChange={handleChange} placeholder="Name" required />
            <input type="email" name="email" value={user.email} onChange={handleChange} placeholder="Email" required />
            <input type="text" name="login" value={user.login} onChange={handleChange} placeholder="Login" required />
            <input type="password" name="password" value={user.password} onChange={handleChange} placeholder="Password" required />
            <input type="text" name="profileImage" value={user.profileImage} onChange={handleChange} placeholder="Profile Image URL" />
            <button type="submit">Create</button>
        </form>
    );
};


export default CreateUser;
