import React, { useEffect, useState } from 'react';
import SubCategories from './SubCategories'
import './Gallery.scss'
import ProductsDisplay from './Products/ProductsDisplay'
import axios, { axiosGet } from '../api/axios';
import ProductsLoad from '../LoadingAnimation/ProductsLoad';
import { Product } from '../models/Product';
import {
  decrement,
  increment,
  selectLoad,
} from '../../features/counter/counterSlice';
import { useAppDispatch } from '../../app/hooks';
function Gallery() {
  const [products, setProducts] : any= useState();  
  const [selectedCategory, SetSelectedCategory] = useState(null);
  const dispatch = useAppDispatch();

  useEffect(() => {
      setProductsArr();
  }, [selectedCategory])

  async function setProductsArr(){
    var response:any;
    dispatch(increment());
    try{
      if(selectedCategory){
        response = await axiosGet('/api/Products/GetProductWithPicturesBySubCategoryId/' + selectedCategory);
      }
      else{
        response = await axiosGet('/api/Products/GetAllProductsWithPictures');
      }
    }
    catch(er : any){
      dispatch(decrement());
    }
    dispatch(decrement());

    setProducts(response.data);
  }

  return (
    <div className="Gallery">
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
