import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { axiosAuthGet, axiosAuthPost } from '../Components/api/axios';
import './CreateProduct.scss';
import Select from 'react-select';
import { useNavigate } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';

function CreateProduct() {
    const dispatch = useDispatch();
    const [valid, setValid] : any = useState(false);
    const [name, setName] : any = useState('');
    const [description, setDescription] : any = useState('');
    const [price, setPrice] : any = useState('');
    const [selectedSubCategoryIds, setSelectedSubCategoryIds] : any = useState('');
    const [pictures, setPictures] : any = useState([]);

    const [files, setFiles] : any = useState([]);
    const [categories, setCategories] : any = useState([]);
    const [subCategories, setSubCategories] : any = useState([]);
    const [selectedCategoryId, setSelectedCategoryId] : any  = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        GetCategories();
        GetSubCategories();
    }, []);

    useEffect(() => {
        if(parseInt(price) > 0 && selectedSubCategoryIds.length > 0){
            setValid(true);
        }
        else{
            setValid(false);
        }
    }, [price, selectedSubCategoryIds]);

    useEffect(() => {
    }, [selectedCategoryId]);

    const SubmitProducts = async () => {
        dispatch(increment());
        var body : any = {
            Id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            Name: name,
            description: description,
            price: parseInt(price),
            imageUrl: "string",
            categories: selectedSubCategoryIds,
            pictures: pictures
          }
        
          try{
            var response = await axiosAuthPost('/api/Products/InsertProduct', body).then((res:any) => 
                    res.status > 210 ? navigate('/CreateProduct') : navigate('/Gallery')
                );
                dispatch(decrement());   
          }
          catch(er:any){
            navigate('/Gallery'); 
            dispatch(decrement());
          }

    }

    const GetSubCategories = async () => {
        var subCats : any = [];
        for(var i = 0; i < categories.length; i++){
            var response = await axiosAuthGet('/api/Products/GetCategories/' + categories[i].value).then((res : any) =>
                subCats.push(handleSetSubCategories(categories[i].label, res.data))
            );
        }
        setSubCategories(subCats);
    }

    const handleSetSubCategories = (name : string, response : any) => {
        var subOptions = [];
        var options = [];
        for(let i = 0; i < response.length; i++){
            subOptions.push({ label: response[i].name, value: response[i].id });
        }
        options.push({
            label: name,
            options: subOptions
        });
        return options[0];
    }

    const GetCategories = async () => {
        var response = await axiosAuthGet('/api/Products/GetCategories').then((res : any) =>
            handleSetCategories(res)
        );
    }

    const toBase64 = (file:any) => new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = error => reject(error);
    });

    const handleSetCategories = (response : any) => {
        setCategories([]);
        var res = response.data;
        var options = [];
        for (let i = 0; i < res.length; i++) {
            options.push({value: res[i].id, label: res[i].name});
        }
        setCategories(options);
        GetSubCategories();
    }

    const handleChangeImage = async (e:any) => {
        for(var i = 0; i < e.target.files.length; i++){
            setFiles([...files, URL.createObjectURL(e.target.files[i])]);
            setPictures([...pictures, await toBase64(e.target.files[i])]);
        }
    }

    const handlePriceChange = (e:any) => {
        var value = e.target.value.replace(/[^0-9.]/g, '').replace(/(\..*?)\..*/g, '$1').replace(/^0[^.]/, '0');
        setPrice(value);
    }

    const handleDelete = (indexToDelete : any) => {
        setFiles(files.filter((item : any, index : any) => indexToDelete !== index));
    }

    const handleSubCategoryIds = (selectedItems : any) => {
        var ids = selectedItems.map((o:any) => o.value);
        setSelectedSubCategoryIds(ids);
    }   
    
  return (
    
    <div className="CreateProduct">
        <div className='CreateProductDisplay'>
            <h3>Create new Product</h3>
                <label>Title</label>
                <input
                    className='inp'
                    type="text"
                    id="username"
                    autoComplete="off"
                    onChange={(e) => setName(e.target.value)}
                    value={name}
                    required
                    />
                    
                <label>Description</label>
                <textarea
                    className='inp'
                    id="username"
                    autoComplete="off"
                    onChange={(e) => setDescription(e.target.value)}
                    value={description}
                    required
                    />

                <label>Price</label>
                <input
                    className='inp'
                    type="text"
                    id="username"
                    autoComplete="off"
                    onChange={(e) => handlePriceChange(e)}
                    value={price}
                    required
                    />  
                <label>Pictures</label>
                <div className='Preview'>
                    {
                        files?.map((file : any, index : any) => 
                            <div key={index} className='ImageWrapper'>
                                <button onClick={() => handleDelete(index)} className='Delete'><i className="fa-sharp fa-solid fa-circle-xmark"></i></button>
                                <img src={file}/>
                            </div>
                        )
                    }
                </div>
                <input type="file" accept="image/png, image/gif, image/jpeg, image/jpg"  multiple onChange={e => handleChangeImage(e)} />
                <label>Choose Category</label>
                <Select className='Selector'
                    closeMenuOnSelect={false}
                    onChange={(choice:any) => handleSubCategoryIds(choice)} 
                    isMulti
                    options={subCategories} />
                <div className='MoveToCheckoutDisplay'>
                    <h3>Total Price: {price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
                    <button disabled={!valid} className={valid ? 'Valid Continue' : 'Continue'} onClick={() => SubmitProducts()}>Create</button>
                </div>

        </div>
    </div>
  );
}

export default CreateProduct;
