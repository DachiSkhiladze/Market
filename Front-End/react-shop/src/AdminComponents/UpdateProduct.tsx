import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { axiosAuthGet, axiosAuthPost, axiosGet } from '../Components/api/axios';
import './CreateProduct.scss';
import Select from 'react-select';
import { useNavigate, useParams } from 'react-router-dom';
import { decrement, increment } from '../features/counter/counterSlice';

function UpdateProduct (){
    const dispatch = useDispatch();
    const [valid, setValid] : any = useState(false);
    const [name, setName] : any = useState('');
    const [description, setDescription] : any = useState('');
    const [price, setPrice] : any = useState('');
    const [selectedSubCategoryIds, setSelectedSubCategoryIds] : any = useState('');
    const [pictures, setPictures] : any = useState(['']);

    const [files, setFiles] : any = useState([]);
    const [categories, setCategories] : any = useState([]);
    const [subCategories, setSubCategories] : any = useState([]);
    const [selectedCategoryId, setSelectedCategoryId] : any  = useState([]);

    const { id } = useParams()
    const navigate = useNavigate();

    useEffect(() => {
        console.log(id);
        GetData();
        GetCategories();
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
        GetSubCategories();
    }, [selectedCategoryId]);

    async function GetData(){
        var response = await axiosGet('/api/Products/GetProductWithPictures/' + id).then((res:any) => 
            InitializeValues(res.data)
        );
    }

    async function InitializeValues(data : any){
        console.log(data.name);
        setName(data.name);
        setDescription(data.description);
        setPrice(data.price);
        var pics = pictures;
        for(var i = 0; i < data.productPictures.length; i++){
            pics.push(data.productPictures[i]);
        }
        setPictures(pics);
    }

    const SubmitProducts = async () => {
        dispatch(increment());
        var body : any = {
            Id: id,
            Name: name,
            description: description,
            price: parseInt(price),
            imageUrl: "string",
            categories: selectedSubCategoryIds,
          }
        
          try{
            var response = await axiosAuthPost('/api/Products/UpdateProduct', body).then((res:any) => 
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
        var response = await axiosAuthGet('/api/Products/GetCategories/' + selectedCategoryId).then((res : any) =>
            handleSetSubCategories(res)
        );
    }

    const handleSetSubCategories = (response : any) => {
        setSubCategories([]);
        var res = response.data;
        var options = [];
        for (let i = 0; i < res.length; i++) {
            options.push({value: res[i].id, label: res[i].name});
        }
        setSubCategories(options);
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


    //Image
    const handleDelete = (indexToDelete : any) => {
        var pics = pictures;
        setPictures([]);
        setPictures(pics.filter((item : any) => item.id !== indexToDelete));
    }

    const handleSubCategoryIds = (selectedItems : any) => {
        var ids = selectedItems.map((o:any) => o.value);
        console.log(ids);
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
                <label>Categories</label>
                <Select className='Selector' 
                        onChange={(choice:any) => setSelectedCategoryId(choice.value)} 
                        options={categories} />
                <label>SubCategories</label>
                <Select className='Selector'
                    onChange={(choice:any) => handleSubCategoryIds(choice)}
                    isMulti
                    options={subCategories} />
                <div className='MoveToCheckoutDisplay'>
                    <h3>Total Price: {price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
                    <button disabled={!valid} className={valid ? 'Valid Continue' : 'Continue'} onClick={() => SubmitProducts()}>Update</button>
                </div>

        </div>
    </div>
  );
}

export default UpdateProduct;
