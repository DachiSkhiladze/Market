import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { axiosAuthGet, axiosAuthPost, axiosGet } from '../Components/api/axios';
import './CreateProduct.scss';
import Select from 'react-select';
import { useNavigate } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';
import { useAppDispatch } from '../app/hooks';

function CreateProduct() {
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
          //response = await axiosGet('/api/Products/GetProductsBySubCategoryID/' + selectedCategory);
        }
        else{
        }
        response = await axiosGet('/api/Products/GetAllProductsWithPictures');
      }
      catch(er : any){
        dispatch(decrement());
      }
      dispatch(decrement());
  
      setProducts(response.data);
    }
    
    const navigate = useNavigate();

  return (
    
    <div className="CreateProduct">
        <div className='CreateProductDisplay'>
            <h3>Create new Product</h3>
        </div>
    </div>
  );
}

export default CreateProduct;
