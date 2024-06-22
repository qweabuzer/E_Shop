// src/components/Products/DeleteProduct.jsx

import React, { useState } from 'react';
import './Products.css';

const DeleteProduct = ({ onDeleteProduct }) => {
    const [productId, setProductId] = useState('');

    const handleChange = (e) => {
        setProductId(e.target.value);
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onDeleteProduct(productId);
    };

    return (
        <form className="product-form" onSubmit={handleSubmit}>
            <h3>Delete Product</h3>
            <input
                type="text"
                name="productId"
                value={productId}
                onChange={handleChange}
                placeholder="Product ID"
                required
            />
            <button type="submit">Delete Product</button>
        </form>
    );
};

export default DeleteProduct;
