// src/components/Products/ProductManagement.jsx

import React, { useState } from 'react';
import '../Management/Management.css'
import CreateProduct from './CreateProduct';
import UpdateProduct from './UpdateProduct';
import ProductList from './ProductList';
import DeleteProduct from './DeleteProduct';
import { fetchProducts, createProduct, updateProduct, deleteProduct } from './products';
import '../Management/Management.css';

const ProductManagement = () => {
    const [products, setProducts] = useState([]);
    const [showProductList, setShowProductList] = useState(false);
    const [showCreateProduct, setShowCreateProduct] = useState(false);
    const [showUpdateProduct, setShowUpdateProduct] = useState(false);
    const [showDeleteProduct, setShowDeleteProduct] = useState(false);

    const loadProducts = async () => {
        const productsData = await fetchProducts();
        setProducts(productsData);
        setShowProductList(true);
        setShowCreateProduct(false);
        setShowUpdateProduct(false);
        setShowDeleteProduct(false);
    };

    const handleCreateProduct = async (product) => {
        await createProduct(product);
        loadProducts();
    };

    const handleUpdateProduct = async (productId, product) => {
        await updateProduct(productId, product);
        loadProducts();
    };

    const handleDeleteProduct = async (productId) => {
        await deleteProduct(productId);
        loadProducts();
    };

    return (
        <center>
        <div className="management-container">
            <h2>Product Management</h2>
            <button className="button" onClick={loadProducts}>Get Products</button>
            <button className="button" onClick={() => { setShowCreateProduct(true); setShowProductList(false); setShowUpdateProduct(false); setShowDeleteProduct(false); }}>Create Product</button>
            <button className="button" onClick={() => { setShowUpdateProduct(true); setShowProductList(false); setShowCreateProduct(false); setShowDeleteProduct(false); }}>Update Product</button>
            <button className="button" onClick={() => { setShowDeleteProduct(true); setShowProductList(false); setShowCreateProduct(false); setShowUpdateProduct(false); }}>Delete Product</button>
            {showProductList && <ProductList products={products} />}
            {showCreateProduct && <CreateProduct onCreateProduct={handleCreateProduct} />}
            {showUpdateProduct && <UpdateProduct onUpdateProduct={handleUpdateProduct} products={products} />}
            {showDeleteProduct && <DeleteProduct onDeleteProduct={handleDeleteProduct} products={products} />}
        </div>
        </center>
    );
};

export default ProductManagement;
