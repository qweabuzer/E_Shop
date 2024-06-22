// src/components/Products/ProductList.jsx

import React from 'react';
import './ProductList.css'; 
const ProductList = ({ products }) => {
    return (
        <div className="product-list">
            <h3>Product List</h3>
            <div className="list-group">
                {products.map(product => (
                    <div key={product.id} className="card">
                        <img 
                            src={product.image || 'https://www.no5.com/media/1772/place-holder-image.png'} 
                            alt={product.name} 
                            className="card-img-top" 
                        />
                        <div className="card-body">
                            <h5 className="card-title">{product.name}</h5>
                            <p className="card-text">Id: {product.id}</p>
                            <p className="card-text">Price: ${product.price}</p>
                            <p className="card-text">Description: {product.description}</p>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default ProductList;
