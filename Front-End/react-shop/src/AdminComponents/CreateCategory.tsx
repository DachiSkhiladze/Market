import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { axiosAuthGet, axiosAuthPost } from '../Components/api/axios';
import './CreateProduct.scss';
import Select from 'react-select';
import { useNavigate } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';

function CreateCategory() {
    const dispatch = useDispatch();
    const [valid, setValid] : any = useState(false);
    const [name, setName] : any = useState('');

    const navigate = useNavigate();

    useEffect(() => {
        if(name.length > 0){
            setValid(true);
        }
        else{
            setValid(false);
        }
    }, [name]);

    const SubmitProducts = async () => {
        dispatch(increment());
        var body : any = {
            Id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            Name: name,
            imageUrl: "string",
          }
        
          try{
            var response = await axiosAuthPost('/api/Category/CreateCategory', body)
                .then((res:any) => res.status > 210 ? navigate('/CreateCategory') : navigate('/Gallery'));
                dispatch(decrement());   
          }
          catch(er:any){
            //navigate('/Gallery'); 
            dispatch(decrement());
          }
    }

    const toBase64 = (file:any) => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });
    
  return (
    
    <div className="CreateProduct">
        <div className='CreateProductDisplay'>
            <h3>Create new Category</h3>
                <label>Category Name</label>
                <input
                    className='inp'
                    type="text"
                    id="username"
                    autoComplete="off"
                    onChange={(e) => setName(e.target.value)}
                    value={name}
                    required
                    />
                <div className='MoveToCheckoutDisplay'>
                    <button disabled={!valid} className={valid ? 'Valid Continue' : 'Continue'} onClick={() => SubmitProducts()}>Create</button>
                </div>
        </div>
    </div>
  );
}

export default CreateCategory;
