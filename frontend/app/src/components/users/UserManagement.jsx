import React, { useState } from 'react';
import '../Management/Management.css';
import CreateUser from './CreateUser';
import UpdateUser from './UpdateUser';
import UserList from './UserList';
import DeleteUser from './DeleteUser';
import { fetchUsers, createUser, updateUser, deleteUser } from './users';

const UserManagement = () => {
    const [users, setUsers] = useState([]);
    const [showUserList, setShowUserList] = useState(false);
    const [showCreateUser, setShowCreateUser] = useState(false);
    const [showUpdateUser, setShowUpdateUser] = useState(false);
    const [showDeleteUser, setShowDeleteUser] = useState(false);

    const loadUsers = async () => {
        const usersData = await fetchUsers();
        setUsers(usersData);
        setShowUserList(true);
        setShowCreateUser(false);
        setShowUpdateUser(false);
        setShowDeleteUser(false);
    };

    const handleCreateUser = async (user) => {
        await createUser(user);
        loadUsers();
    };

    const handleUpdateUser = async (user) => {
        await updateUser(user.id, user);
        loadUsers();
    };

    const handleDeleteUser = async (userId) => {
        await deleteUser(userId);
        loadUsers();
    };

    return (
        <center>
        <div className="management-container">
            <h2>User Management</h2>
            <div className="button-container">
                <button className="button" onClick={loadUsers}>Get Users</button>
                <button className="button" onClick={() => { setShowCreateUser(true); setShowUserList(false); setShowUpdateUser(false); setShowDeleteUser(false); }}>Create User</button>
                <button className="button" onClick={() => { setShowUpdateUser(true); setShowUserList(false); setShowCreateUser(false); setShowDeleteUser(false); }}>Update User</button>
                <button className="button" onClick={() => { setShowDeleteUser(true); setShowUserList(false); setShowCreateUser(false); setShowUpdateUser(false); }}>Delete User</button>
            </div>
            <div className="form-container" show={showCreateUser || showUpdateUser || showDeleteUser}>
                {showCreateUser && <CreateUser onCreateUser={handleCreateUser} />}
                {showUpdateUser && <UpdateUser onUpdateUser={handleUpdateUser} users={users} />}
                {showDeleteUser && <DeleteUser onDeleteUser={handleDeleteUser} />}
            </div>
            {showUserList && <UserList users={users} />}
        </div>
        </center>
    );
};

export default UserManagement;
