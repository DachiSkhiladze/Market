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
                        <div className='TitleContainer'>
                          <h1>{item?.name}</h1>
                        </div>
                        <div className='AddContainer'>
                            <button onClick={() => addinCart(item.id)}>
                              <i className="fa-solid fa-cart-plus"></i>
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
