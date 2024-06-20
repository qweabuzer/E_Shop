// Файл: src/components/Users/users.js

import axios from 'axios';

export const fetchUsers = async () => {
    try {
        const response = await axios.get('https://localhost:7222/Users/GetAll');
        return response.data;
    } catch (error) {
        console.error('Ошибка при загрузке пользователей', error);
        return [];
    }
};

export const createUser = async (user) => {
    try {
        const response = await axios.post('https://localhost:7222/Users/Create', user);
        return response.data;
    } catch (error) {
        console.error('Ошибка при создании пользователя', error);
        throw error;
    }
};

export const updateUser = async (userId, user) => {
    try {
        const response = await axios.put(`https://localhost:7222/Users/Update?userId=${userId}`, user);
        return response.data;
    } catch (error) {
        console.error('Ошибка при обновлении пользователя', error);
        throw error;
    }
};

export const deleteUser = async (userId) => {
    try {
        const response = await axios.delete(`https://localhost:7222/Users/Delete?userId=${userId}`);
        return response.data;
    } catch (error) {
        console.error('Ошибка при удалении пользователя', error);
        throw error;
    }
};
