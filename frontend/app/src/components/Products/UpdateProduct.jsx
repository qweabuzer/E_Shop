// src/components/Products/UpdateProduct.jsx

import React, { useState } from 'react';
import './Products.css'; 

const UpdateProduct = ({ onUpdateProduct }) => {
    const [product, setProduct] = useState({
        id: '',
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
        onUpdateProduct(product);
    };

    return (
        <form className="product-form" onSubmit={handleSubmit}>
            <h3>Update Product</h3>
            <input
                type="text"
                name="id"
                value={product.id}
                onChange={handleChange}
                placeholder="Product ID"
                required
            />
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
            <button type="submit">Update Product</button>
        </form>
    );
};

export default UpdateProduct;
