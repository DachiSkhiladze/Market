import { useEffect, useState } from 'react';
import { axiosAuthGet, axiosAuthPost, axiosGet } from '../Components/api/axios';
import '../AdminComponents/List.scss';
import { useNavigate } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';
import { useAppDispatch } from '../app/hooks';

function Orders() {
    const [products, setProducts] : any = useState([]);
    const [roles, setRoles] : any = useState([]);

    const dispatch = useAppDispatch();
  
    useEffect(() => {
        setProductsArr();
    }, [])

    async function setProductsArr(){
      var response:any;
      dispatch(increment());
      try{
        response = await axiosAuthGet('/api/Employee/GetOrders')
            .then((results : any) => setProducts(results.data));
      }
      catch(er : any){
        dispatch(decrement());
      }
      dispatch(decrement());
    }
    

    async function DoneOrder(orderId : string){
        var tmp = [];
        console.log(orderId);
        for(var i = 0; i < products.length; i++){
          if(products[i].id === orderId){
            var product = products[i];
            product.status = "Done";
            tmp.push(product);
          }
          else{
            tmp.push(products[i]);
          }
        }
        var response = await axiosAuthGet('/api/Employee/SetProductDone/' + orderId);
        setProducts(tmp);
    }

  return (
    
    <div className="Orders Products">
            <h3>Orders</h3>
            {products?.map((item : any)=>{
                return (
                    <div className='User Product' key={item.id}>
                        <div className='title'>
                            <div className='Details'>
                            <table>
                                            <tr className='DetailsHeader'>
                                                <th></th>
                                                <th>Product Name</th>
                                                <th>Price of Single Products</th>
                                                <th>Quantity</th>
                                            </tr>
                                {item?.orders.map((order : any, index : any) => {
                                    return(
                                        <tr>
                                            <th>{index + 1}</th>
                                            <th>{order?.name}</th>
                                            <th>{order?.priceOfSingleProduct} USD</th>
                                            <th>{order?.quantity} </th>
                                        </tr>
                                    )
                                })}
                                </table>
                            </div>
                        </div>
                        <div className='operationsContainer'>
                            <div className='Done'>
                                <h2>Address: {item?.address}</h2>
                                <button onClick={() => DoneOrder(item?.id)} className={item?.status !== 'In Proccess' ? 'Done' : 'Process'} disabled={item?.status !== 'In Proccess' ? true : false}>{item?.status !== 'In Proccess' ? 'Done' : 'In Process'}</button>
                            </div>
                        </div>
                    </div>
                )
            })}
    </div>
  );
}

export default Orders;
