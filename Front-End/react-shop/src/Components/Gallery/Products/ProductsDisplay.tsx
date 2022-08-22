import React, { useEffect, useState } from 'react';
import { Product } from '../../models/Product';
import './ProductsDisplay.scss'

const ProductsDisplay: React.FC<{products:any}> = ({products}) => {
    
  return (
    <div className="ProductsDisplay">
              {products?.map((item : Product)=>{
                return (
                    <div key={item?.name} className='cat'>
                        <button>
                            <h1>{item?.name}</h1>
                        </button>
                    </div>
                )
                }
              )
              }
    </div>
  );
}

export default ProductsDisplay;
