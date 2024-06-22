// src/components/Products/CreateProduct.jsx

import React, { useState } from 'react';
import './Products.css'; 
const CreateProduct = ({ onCreateProduct }) => {
    const [product, setProduct] = useState({
        name: '',
        price: '',
        description: '',
        image: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setProduct((prevProduct) => ({
            ...prevProduct,
            [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onCreateProduct(product);
    };

    return (
        <form className="product-form" onSubmit={handleSubmit}>
            <h3>Create Product</h3>
            <input
                type="text"
                name="name"
                value={product.name}
                onChange={handleChange}
                placeholder="Name"
                required
            />
            <input
                type="number"
                name="price"
                value={product.price}
                onChange={handleChange}
                placeholder="Price"
                required
            />
            <input
                type="text"
                name="description"
                value={product.description}
                onChange={handleChange}
                placeholder="Description"
                required
            />
            <input
                type="text"
                name="image"
                value={product.image}
                onChange={handleChange}
                placeholder="Image URL"
            />
            <button type="submit">Create Product</button>
        </form>
    );
};

export default CreateProduct;
