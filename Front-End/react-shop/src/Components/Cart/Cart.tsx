import { privateDecrypt } from 'crypto';
import { useEffect, useState } from 'react';
import { axiosAuthGet } from '../api/axios';
import './Cart.scss'

function Cart() {
    const [cartProducts, setCartProducts] : any = useState([]);  
    const [item, setItem] : any = useState();
    const [price, setPrice] : any = useState();
    useEffect(() => {
        setProductsArr();
    }, [])

    useEffect(() => {
      GetSumPrice(cartProducts);
      if(item == null)
      {
        return;
      }
      const typingTimeOut = setTimeout(async function() {
        var response = await axiosAuthGet('/api/Cart/AddInCart/' + item.product.id + '?quantity=' + item.quantity);
      }, 500);
      return () => {
        clearTimeout(typingTimeOut);
      }
    }, [cartProducts])
  
      var delay = (function () {
        var timer:any = 0;
        return function (callback:any, ms:any) {
            clearTimeout(timer);
            timer = setTimeout(callback, ms);
        };
    })()

    function GetSumPrice(pr:any){
      var sumPrice = 0;
      for(var i = 0; i < pr?.length; i++){
        sumPrice += pr[i].product.price * pr[i].quantity;
      }
      setPrice(sumPrice);
    }

    async function setProductsArr(){
      var response = await axiosAuthGet('/api/Cart/GetCartItems');
      setCartProducts(response.data);
      GetSumPrice(response.data);
    }

    async function Minus(index:any){
      var item = cartProducts[index];
      if(item.quantity-1 == 0){
        return;
      }
      item.quantity--;
      setItem(item);
      setCartProducts((datas : any) => ([
        ...cartProducts
      ]))
    }
    
    async function Plus(index:any){
      var item = cartProducts[index];
      item.quantity++;
      setItem(item);
      setCartProducts((datas : any) => ([
        ...cartProducts
      ]))
    }
    
    async function Delete(id:any){
      setItem(null);
      setCartProducts(cartProducts.filter((item:any) => item.product.id !== id));
      var response = await axiosAuthGet('/api/Cart/DeleteProductFromCart/' + id);
    }
  
    return (
      <div className="Cart">
        <div className='CartProductsDisplay'>
        {cartProducts?.map((item : any, index : any)=>{
                return (
                  <div key={index} className='pr'>
                    <div key={item?.id} className='cartProduct'>
                        <h1>{item?.product?.name}</h1>
                        <h2>price: {item?.product.price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")}</h2>

                    </div>
                    <div>
                      <div className='CartProductActionsDisplay'>
                        <div className='quantityDisplay'>
                          <button onClick={() => Minus(index)} className='minus'>
                                <i className="fa-solid fa-minus"></i>
                          </button>
                          <p>{item.quantity}</p>
                          <button onClick={() => Plus(index)} className='plus'>
                                <i className="fa-solid fa-plus"></i>
                          </button>
                        </div>
                        
                        <button onClick={() => Delete(item.product.id)} className='trash'>
                          <i className="fa-sharp fa-solid fa-trash"></i>
                        </button>
                      </div>
                    </div>
                  </div>
                )
                }
              )
            }
        </div>
        <div>
            <h3>Total Unique Items: {cartProducts.length}</h3>
            <h3>Total Price: {price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
            <button className='Continue'>Continue To Checkout</button>
        </div>
      </div>
    );
  }

  export default Cart;