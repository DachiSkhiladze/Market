import{
    logIn,
    logOut,
} from '../Authorization/reducer/logger'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import axios from 'axios';
import { useEffect } from 'react';
import { store } from '../../app/store';
import {
    decrement,
    increment,
    incrementByAmount,
    selectLoad
  } from '../../features/counter/counterSlice';

//const BASE_URL = 'https://marketplacefrt.azurewebsites.net';
const BASE_URL = 'https://localhost:7223';
const REFRESH_METHOD_URL = '/api/User/refresh-token'


export default axios.create({
    baseURL: BASE_URL
});

export const axiosPrivate = axios.create({
    baseURL: BASE_URL,
    headers: { 'Content-Type': 'application/json' },
    withCredentials: true
});

export const axiosGet = async (url : string) => {
    const response = await axios.get(BASE_URL + url, {
        headers: {
            'Content-Type': 'application/json'
        }}
    )
    console.log(response.data)
    return response;
}

export const axiosAuthGet : any = async (methodUrl : string) => {
    var tkn = localStorage.getItem('token')!;
    var token : any = JSON.parse(tkn);

    try{
        const response = await axios.get(BASE_URL+methodUrl, {
            headers: {
                'Authorization': 'Bearer ' + token.accessToken,
                'Content-Type': 'application/json',
            }}
        )
        if(response.status > 240){
            var isRefreshed : boolean = await refreshToken();
            if(isRefreshed){
                //axiosAuthGet(methodUrl);
            }
        }
        return response;
    }
    catch(err:any){
        var isRefreshed : boolean = false;
            //await refreshToken();
        if(isRefreshed){
            //return axiosAuthGet(methodUrl);
        }
    }
}

const refreshToken = async () => {
    
    var tkn = localStorage.getItem('token')!;
    var token : any = JSON.parse(tkn);
    var tokenModel = token.refreshToken;
    store.dispatch(increment);
    const response = await axios.post(BASE_URL + REFRESH_METHOD_URL, tokenModel, {
        headers: {
            'Content-Type': 'application/json'
        }},
    );
    localStorage.setItem('token', JSON.stringify(response?.data));
    store.dispatch(decrement);
    if(response.status < 250){
        return true;
    }
    //store.dispatch(logOut()); // log out of system
    return false;
}
