import React, { useEffect, useState } from 'react';
import { Product } from '../../models/Product';
import { axiosAuthGet } from '../../api/axios';
import './ProductsDisplay.scss';

const ProductsDisplay: React.FC<{products:any}> = ({products}) => {


  async function addinCart(id:string){
  const METHOD_URL = '/api/Cart/AddInCart/  ';
    try {
      const response = await axiosAuthGet(METHOD_URL + id);
      
    } catch (err:any) {
      
    }
  }

  return (
    <div className="ProductsDisplay">
              {products?.map((item : Product)=>{
                return (
                    <div key={item?.id} className='product'>
                        <div className='ViewMore'>
                          <h1>View More</h1>
                        </div>
                      <div className='PictureContainer'>
                        <img src={item?.pictures[0]} alt="" />
                      </div>
                        <div className='TitleContainer'>
                          <h1><span>{item?.name}</span></h1>
                          <h3>{item?.price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
                        </div>
                        <div className='AddContainer'>
                            <button onClick={() => addinCart(item.id)}>
                              <p>add in cart</p>
                            </button>
                        </div>
                    </div>
                )
                }
              )
              }
    </div>
  );
}

export default ProductsDisplay;
