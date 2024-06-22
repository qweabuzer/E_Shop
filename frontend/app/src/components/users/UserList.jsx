import React from 'react';
import './UserList.css';

const UserList = ({ users }) => {
    return (
        <div className="user-list">
            <h3>User List</h3>
            <div className="list-group">
                {users.map(user => (
                    <div key={user.id} className="card">
                        <img 
                            src={user.profileImage || 'https://www.no5.com/media/1772/place-holder-image.png'} 
                            alt={user.name} 
                            className="card-img-top user-image" 
                        />
                        <div className="card-body user-details">
                            <h5 className="card-title">{user.name}</h5>
                            <p className="card-text">Id: {user.id}</p>
                            <p className="card-text">Email: {user.email}</p>
                            <p className="card-text">Login: {user.login}</p>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default UserList;
