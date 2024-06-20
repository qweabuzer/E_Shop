// Файл: src/components/AdminPanel/AdminPanel.js

import React, { useState } from 'react';
import { fetchUsers, createUser, updateUser, deleteUser } from '../UserList/users';
import UserList from '../UserList/UserList';
import './AdminPanel.css';

const AdminPanel = () => {
    const [users, setUsers] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [isFetched, setIsFetched] = useState(false);
    const [formType, setFormType] = useState(null);
    const [formData, setFormData] = useState({
        id: '',
        name: '',
        email: '',
        login: '',
        password: '',
        profileImage: '',
    });

    const getUsers = async () => {
        setIsLoading(true);
        setFormType(null); 
        try {
            const data = await fetchUsers();
            setUsers(data);
            setIsFetched(true);
        } catch (error) {
            console.error('Ошибка при загрузке пользователей:', error);
        } finally {
            setIsLoading(false);
        }
    };

    const resetView = () => {
        setUsers([]);
        setIsFetched(false);
        setFormType(null);
        setFormData({
            id: '',
            name: '',
            email: '',
            login: '',
            password: '',
            profileImage: '',
        });
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleCreateUser = async () => {
        try {
            const response = await createUser(formData);
            alert('User created successfully!');
            resetView();
        } catch (error) {
            console.error('Ошибка при создании пользователя:', error);
        }
    };

    const handleUpdateUser = async () => {
        try {
            const response = await updateUser(formData.id, formData);
            alert('User updated successfully!');
            resetView();
        } catch (error) {
            console.error('Ошибка при обновлении пользователя:', error);
        }
    };

    const handleDeleteUser = async () => {
        try {
            const response = await deleteUser(formData.id);
            alert('User deleted successfully!');
            resetView();
        } catch (error) {
            console.error('Ошибка при удалении пользователя:', error);
        }
    };

    const renderForm = () => {
        if (!formType) return null;

        return (
            <div className="form-container">
                <h3>{formType === 'create' ? 'Create User' : formType === 'update' ? 'Update User' : 'Delete User'}</h3>
                {(formType === 'update' || formType === 'delete') && (
                    <div className="form-group">
                        <label>User ID</label>
                        <input type="text" name="id" value={formData.id} onChange={handleInputChange} className="form-control" />
                    </div>
                )}
                {(formType === 'create' || formType === 'update') && (
                    <>
                        <div className="form-group">
                            <label>Name</label>
                            <input type="text" name="name" value={formData.name} onChange={handleInputChange} className="form-control" />
                        </div>
                        <div className="form-group">
                            <label>Email</label>
                            <input type="email" name="email" value={formData.email} onChange={handleInputChange} className="form-control" />
                        </div>
                        <div className="form-group">
                            <label>Login</label>
                            <input type="text" name="login" value={formData.login} onChange={handleInputChange} className="form-control" />
                        </div>
                        <div className="form-group">
                            <label>Password</label>
                            <input type="password" name="password" value={formData.password} onChange={handleInputChange} className="form-control" />
                        </div>
                        <div className="form-group">
                            <label>Profile Image URL</label>
                            <input type="text" name="profileImage" value={formData.profileImage} onChange={handleInputChange} className="form-control" />
                        </div>
                    </>
                )}
                <button onClick={formType === 'create' ? handleCreateUser : formType === 'update' ? handleUpdateUser : handleDeleteUser} className="btn btn-primary">
                    {formType === 'create' ? 'Create' : formType === 'update' ? 'Update' : 'Delete'}
                </button>
            </div>
        );
    };

    return (
        <div className="admin-panel container">
            <h2 className="text-center my-4">Admin Panel</h2>
            <div className="d-flex justify-content-center mb-4">
                {!isFetched ? (
                    <button onClick={getUsers} disabled={isLoading} className="btn btn-primary mx-2">
                        {isLoading ? 'Loading...' : 'Get Users'}
                    </button>
                ) : (
                    <button onClick={resetView} className="btn btn-secondary mx-2">
                        Cancel
                    </button>
                )}
                <button onClick={() => { setFormType('create'); setIsFetched(false); }} className="btn btn-success mx-2">Create User</button>
                <button onClick={() => { setFormType('update'); setIsFetched(false); }} className="btn btn-warning mx-2">Update User</button>
                <button onClick={() => { setFormType('delete'); setIsFetched(false); }} className="btn btn-danger mx-2">Delete User</button>
            </div>
            {renderForm()}
            {isFetched && <UserList users={users} />}
        </div>
    );
};

export default AdminPanel;
