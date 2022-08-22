import React, { useEffect, useState } from 'react';
import SubCategories from './SubCategories'
import './Gallery.scss'
import ProductsDisplay from './Products/ProductsDisplay'
import axios, { axiosGet } from '../api/axios';
import { Product } from '../models/Product';

function Gallery() {
  const [products, setProducts] : any= useState();  
  const [selectedCategory, SetSelectedCategory] = useState(null);

  useEffect(() => {
      setProductsArr();
  }, [selectedCategory])

  async function setProductsArr(){
    var productsArr;
    if(selectedCategory){
      productsArr = await axiosGet('/api/Products/GetProductsBySubCategoryID/' + selectedCategory);
    }
    else{
      productsArr = await axiosGet('/api/Products/GetAllProducts');
    }
    setProducts(productsArr);
  }

  return (
    <div className="Gallery">
        <div className='sideMenu'>
            <SubCategories />
        </div>
        <div className='ProductsDisplay'>
            <ProductsDisplay products={products}/>
        </div>
    </div>
  );
}

export default Gallery;
