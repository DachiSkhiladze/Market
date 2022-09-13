import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { axiosAuthGet, axiosAuthPost } from '../Components/api/axios';
import './CreateProduct.scss';
import Select from 'react-select';
import { useNavigate } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';

function CreateSubCategory() {
    const dispatch = useDispatch();
    const [valid, setValid] : any = useState(false);
    const [name, setName] : any = useState('');
    const [categoryId, setCategoryId] : any = useState('');

    const [categories, setCategories] : any = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        GetCategories();
    }, []);

    useEffect(() => {
        if(name.length > 0){
            setValid(true);
        }
        else{
            setValid(false);
        }
    }, [name]);

    const handleSetCategories = (response : any) => {
        setCategories([]);
        var res = response.data;
        var options = [];
        for (let i = 0; i < res.length; i++) {
            options.push({value: res[i].id, label: res[i].name});
        }
        setCategories(options);
    }


    const SubmitProducts = async () => {
        dispatch(increment());
        var body : any = {
            Id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            Name: name,
            categoryId: categoryId,
            imageUrl: "string"
          }
        
          try{
            var response = await axiosAuthPost('/api/SubCategory/CreateSubCategory', body).then((res:any) => 
                    res.status > 210 ? navigate('/CreateProduct') : navigate('/Gallery')
                );
                dispatch(decrement());   
          }
          catch(er:any){
            navigate('/Gallery'); 
            dispatch(decrement());
          }

    }

    const GetCategories = async () => {
        var response = await axiosAuthGet('/api/Products/GetCategories').then((res : any) =>
            handleSetCategories(res)
        );
    }
    
  return (
    
    <div className="CreateProduct">
        <div className='CreateProductDisplay'>
            <h3>Create new Product</h3>
                <label>Sub Category Name</label>
                <input
                    className='inp'
                    type="text"
                    id="username"
                    autoComplete="off"
                    onChange={(e) => setName(e.target.value)}
                    value={name}
                    required
                    />
                <label>Categories</label>
                <Select className='Selector' 
                        onChange={(choice:any) => setCategoryId(choice.value)}
                        options={categories} />
                <div className='MoveToCheckoutDisplay'>
                    <button disabled={!valid} className={valid ? 'Valid Continue' : 'Continue'} onClick={() => SubmitProducts()}>Create</button>
                </div>

        </div>
    </div>
  );
}

export default CreateSubCategory;
