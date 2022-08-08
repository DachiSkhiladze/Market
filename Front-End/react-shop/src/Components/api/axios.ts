import{
    logIn,
    logOut,
} from '../Authorization/reducer/logger'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import axios from 'axios';
import { useEffect } from 'react';
import { store } from '../../app/store';

const BASE_URL = 'https://localhost:7223';
const REFRESH_METHOD_URL = '/User/refresh-token'


export default axios.create({
    baseURL: BASE_URL
});

export const axiosPrivate = axios.create({
    baseURL: BASE_URL,
    headers: { 'Content-Type': 'application/json' },
    withCredentials: true
});

export const axiosGet = async (url : string) => {
    const response = await axios.get(url, {
        headers: {
            'Content-Type': 'application/json'
        }}
    )
    return response;
}

export const axiosAuthGet = async (methodUrl : string) => {
    var tkn = localStorage.getItem('token')!;
    var token : any = JSON.parse(tkn);

    try{
        const response = await axios.get(BASE_URL+methodUrl, {
            headers: {
                'Authorization': 'Bearer ' + token.accessToken,
                'Content-Type': 'application/json',
            }}
        )
        
        return response;
    }
    catch(err:any){
        var isRefreshed : boolean = await refreshToken();
        if(isRefreshed){
            axiosAuthGet(methodUrl);
        }
        else{
            store.dispatch(logOut());
        }
    }
}

const refreshToken = async () => {
    
    var tkn = localStorage.getItem('token')!;
    var token : any = JSON.parse(tkn);
    var tokenModel = token.refreshToken;
    const response = await axios.post(BASE_URL + REFRESH_METHOD_URL, tokenModel, {
        headers: {
            'Content-Type': 'application/json'
        }},
    );
    localStorage.setItem('token', JSON.stringify(response?.data));
    if(response?.data.length > 1){
        return true;
    }
    return false;
}
