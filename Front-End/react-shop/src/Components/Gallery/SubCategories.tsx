import React, { useEffect, useState } from 'react';
import { axiosAuthGet, axiosGet } from '../api/axios'
import './SubCats.scss'
import {
    decrement,
    increment
  } from '../../features/counter/counterSlice';
import { useDispatch } from 'react-redux';
import { SubCategoryModel } from './SubCategoryModel';


const METHOD_URL = '/api/Products/GetCategories/';

const SubCategories: React.FC<{SetSelectedCategory:any}> = ({SetSelectedCategory}) => {
    const [subCategories, setSubCategories] = useState<SubCategoryModel[]>([]);

    const dispatch = useDispatch();

    const load = async () => {
        dispatch(increment());
        try {
            var categoryId = 'eca89582-50b9-4ea6-8445-589be64ca7db';
            const response = await axiosGet(METHOD_URL + categoryId);
            
            if(response!.status < 250)
            {
                setSubCategories(response?.data);
            }
            
        } catch (err:any) {

        }
        dispatch(decrement());
    } 

    useEffect(() => {
        load();
    }, []);
  return (
    <div className="SubCategories">
        {subCategories.map((item : SubCategoryModel)=>{
            return (
                <div key={item.id} className='cat'>
                    <button onClick={() => SetSelectedCategory(item.id)}>
                        <h1>{item.name}</h1>
                    </button>
                </div>
            )
        })}
    </div>
  );
}

export default SubCategories;
