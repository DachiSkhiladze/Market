import { useEffect, useState } from 'react';
import { axiosAuthGet } from '../api/axios';
import './Cart.scss'

function Cart() {
    const [cartProducts, setCartProducts] : any = useState();  
  
    useEffect(() => {
        setProductsArr();
    }, [])
  
    async function setProductsArr(){
      var response = await axiosAuthGet('/api/Cart/GetCartItems');
      setCartProducts(response.data);
      console.log(cartProducts);
    }

    function Minus(index:any){
      var item = cartProducts;
      item[index].quantity--;
      setCartProducts(item);
    }
  
    return (
      <div className="Cart">
        {cartProducts?.map((item : any, index : any)=>{
                return (
                    <div key={item?.id} className='cartProduct'>
                        <h1>{item?.product?.name}</h1>
                        <div className='quantityDisplay'>
                          <button onClick={() => Minus(index)} className='minus'>
                                <i className="fa-solid fa-minus"></i>
                          </button>
                          <p>{item.quantity}</p>
                          <button className='plus'>
                                <i className="fa-solid fa-plus"></i>
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

  export default Cart;