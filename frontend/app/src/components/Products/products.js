// src/components/Products/products.js

import axios from 'axios';

export const fetchProducts = async () => {
    try {
        const response = await axios.get('https://localhost:7222/Products/GetAll');
        return response.data;
    } catch (error) {
        console.error('Ошибка при загрузке продуктов', error);
        return [];
    }
};

export const createProduct = async (product) => {
    try {
        const response = await axios.post('https://localhost:7222/Products/Create', product);
        return response.data;
    } catch (error) {
        console.error('Ошибка при создании продукта', error);
        throw error;
    }
};

export const updateProduct = async (productId, product) => {
    try {
        const response = await axios.put(`https://localhost:7222/Products/Update?productId=${productId}`, product);
        return response.data;
    } catch (error) {
        console.error('Ошибка при обновлении продукта', error);
        throw error;
    }
};

export const deleteProduct = async (productId) => {
    try {
        const response = await axios.delete(`https://localhost:7222/Products/Delete?productId=${productId}`);
        return response.data;
    } catch (error) {
        console.error('Ошибка при удалении продукта', error);
        throw error;
    }
};
