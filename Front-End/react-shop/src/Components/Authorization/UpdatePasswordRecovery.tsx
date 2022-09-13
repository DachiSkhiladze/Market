import logo from './logo.svg';
import axios from '../api/axios';
import AuthorizationLayer from './AuthorizationLayer'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import './ForgotPassword.scss'
import Load from './../LoadingAnimation/Load';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import {
  decrement,
  increment,
  incrementByAmount,
  selectLoad
} from '../../features/counter/counterSlice';

const SENDRECORVERYMAIL_URL = '/api/User/RecoverPassword';

const ForgotPassword: React.FC<{token:string}> = ({ token }) => {
  
  const load = useAppSelector(selectLoad);
  const dispatch = useAppDispatch();
  const [password, setPassword] = useState('');
  const [change, setChange] = useState(0); // 1 Success 2  3 
  const [error, setError] = useState('');

  const navigate = useNavigate();

  useEffect(() => {

  }, []);

  const handleSubmit = async (e:any) => {
    e.preventDefault();
    dispatch(increment());
    try {
        const model = JSON.stringify({
            "email": "",
            "code": token,
            "password": password
          });
        const response = await axios.post(SENDRECORVERYMAIL_URL, model, {
            headers: {
                'Content-Type': 'application/json'
            }}
        )
        if(response.status < 250)
        {
            setChange(1);
        }
        else if(response.status === 404){
            setChange(2);
        }
        else if(response.status === 400){
            setChange(3);
            setError("Password is not strong enough");
        }
        
        setTimeout(() => {
            navigate("/login");
          }, 2000);
    } catch (err:any) {
        setChange(3);
        setError("Password is not strong enough");

    }
    dispatch(decrement());
}
//{errMsg.length > 0 ? <LoginFailure /> : <></>}
  return (
    <div className='ForgotPassword'>
        {
            change == 1 ? 
            <div className='RecoverySubmitted'>
                <h1 className='isTextCentered isColorBlue'>Password Updated</h1>
            </div>
            : 
            change == 2 ?
            <div className='RecoverySubmitted'>
                <h1 className='isTextCentered isColorBlue'>URL is Expired</h1>
                <h1 className='isTextCentered'>Password cannot be changed</h1>
            </div>
            :
            <form onSubmit={handleSubmit}>
                <h3 className='hasSmallVerticalMargin'>Password Recovery</h3>
                {error === '' ? <></> : <h4 style={{color: 'red'}}>Password is not strong enough</h4>}
                <div className='hasSmallVerticalMargin'>
                    <label htmlFor="password">New Password</label>
                    <input
                        type="password"
                        id="password"
                        onChange={(e) => setPassword(e.target.value)}
                        value={password}
                        required
                    />
                </div>
                    <button className='submit'>Submit</button>
                <p>
                    <span className="line">
                    </span>
                </p>
            </form>
        }
    </div>
  );
}

export default ForgotPassword;