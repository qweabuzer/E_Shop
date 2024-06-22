import React, { useState } from 'react';
import './Users.css';

const DeleteUser = ({ onDeleteUser }) => {
    const [userId, setUserId] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onDeleteUser(userId);
        setUserId('');
    };

    return (
        <div className="user-form">
            <h3>Delete User</h3>
            <input
                type="text"
                value={userId}
                onChange={(e) => setUserId(e.target.value)}
                placeholder="User ID"
                required
            />
            <button onClick={handleSubmit}>Delete</button>
        </div>
    );
};

export default DeleteUser;
