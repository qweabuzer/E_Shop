// Файл: src/components/UserList/UserList.js

import React from 'react';
import './UserList.css';

const UserList = ({ users }) => {
    return (
        <div className="user-list">
            <h3>User List</h3>
            <div className="list-group">
                {users.map(user => (
                    <div key={user.id} className="list-group-item">
                        <img 
                            src={user.profileImage || 'https://www.no5.com/media/1772/place-holder-image.png'} 
                            alt={user.name} 
                            className="user-image" 
                        />
                        <div className="user-details">
                            <h5>{user.name}</h5>
                            <p>Id: {user.id}</p>
                            <p>Email: {user.email}</p>
                            <p>Login: {user.login}</p>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default UserList;
