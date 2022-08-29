import React, { useEffect, useState } from 'react';
import SubCategories from './SubCategories'
import './Gallery.scss'
import ProductsDisplay from './Products/ProductsDisplay'
import axios, { axiosGet } from '../api/axios';
import ProductsLoad from '../LoadingAnimation/ProductsLoad';
import { Product } from '../models/Product';

function Gallery() {
  const [products, setProducts] : any= useState();  
  const [selectedCategory, SetSelectedCategory] = useState(null);

  useEffect(() => {
      setProductsArr();
  }, [selectedCategory])

  async function setProductsArr(){
    var response;
    if(selectedCategory){
      response = await axiosGet('/api/Products/GetProductsBySubCategoryID/' + selectedCategory);
    }
    else{
      response = await axiosGet('/api/Products/GetAllProducts');
    }
    setProducts(response.data);
  }

  return (
    <div className="Gallery">
      <h1>{selectedCategory}</h1>
        <div className='sideMenu'>
            <SubCategories SetSelectedCategory = {SetSelectedCategory}/>
        </div>
        <div className='ProductsContainer'>
            <ProductsDisplay products={products}/>
        </div>
    </div>
  );
}

export default Gallery;
