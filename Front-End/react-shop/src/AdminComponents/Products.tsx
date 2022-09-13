import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { axiosAuthGet, axiosAuthPost, axiosGet } from '../Components/api/axios';
import './List.scss';
import Select from 'react-select';
import { useNavigate } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';
import { useAppDispatch } from '../app/hooks';
import { Product } from '../Components/models/Product';

function Products() {
    const [products, setProducts] : any= useState([]);  
    const [selectedCategory, SetSelectedCategory] = useState(null);
    const dispatch = useAppDispatch();
  
    useEffect(() => {
        setProductsArr();
    }, [])
  
    async function setProductsArr(){
      var response:any;
      dispatch(increment());
      try{
        response = await axiosGet('/api/Products/GetAllProducts')
            .then(results => setProducts(results.data));
      }
      catch(er : any){
        dispatch(decrement());
      }
      dispatch(decrement());
    }

    async function deleteProduct(id:any){
        var response:any;
        dispatch(increment());
        try{
          response = await axiosGet('/api/Products/DeleteProduct/' + id);
        }
        catch(er : any){
          dispatch(decrement());
        }
        if(response?.status < 240){
            setProducts(products.filter((item : any) => item.id !== id));
        }
        dispatch(decrement());
    }
    
    const navigate = useNavigate();

    function updateProduct(id : string){
        navigate('/updateProduct/' + id)
    }


  return (
    
    <div className="Products">
            <h3>Products</h3>
            
            {products?.map((item : Product)=>{
                return (
                    <div className='Product' key={item.id}>
                        <div className='title'>
                            <h1>{item?.name}</h1>
                        </div>
                        <div className='operationsContainer'>
                            <div className='Update'>
                                <button onClick={() => updateProduct(item?.id)}>Update</button>
                            </div>
                            <div className='Delete'>
                                <button onClick={async () => await deleteProduct(item?.id)}>Delete</button>
                            </div>
                        </div>
                    </div>
                )
            })}
    </div>
  );
}

export default Products;
