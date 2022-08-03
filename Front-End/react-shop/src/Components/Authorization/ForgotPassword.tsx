import logo from './logo.svg';
import { Counter } from '../../features/counter/Counter';
import axios from '../api/axios';
import AuthorizationLayer from './AuthorizationLayer'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import './ForgotPassword.scss'
import Load from './../LoadingAnimation/Load';
import React, { useEffect, useState } from 'react';
import {
  decrement,
  increment,
  incrementByAmount,
  selectLoad
} from '../../features/counter/counterSlice';

const SENDRECORVERYMAIL_URL = '/User/SendRecoveryMail';

function ForgotPassword() {
  
  const load = useAppSelector(selectLoad);
  const dispatch = useAppDispatch();
  const [email, setEmail] = useState('');
  const [submit, setSumbit] = useState(false);


  useEffect(() => {
    dispatch(decrement());
  }, []);

  const handleSubmit = async (e:any) => {
    e.preventDefault();
    dispatch(increment());
    try {
        const model = JSON.stringify({
            "email": email
          });
        const response = await axios.post(SENDRECORVERYMAIL_URL, model, {
            headers: {
                'Content-Type': 'application/json'
            }}
        )
        if(response.status !== null)
        {
            setSumbit(true); 
        }
    } catch (err:any) {
        setSumbit(true);
    }
    dispatch(decrement());
}

  return (
    <div className='ForgotPassword'>
        {submit ? 
        <div className='RecoverySubmitted'>
            <h1 className='isTextCentered isColorBlue'>Submitted</h1>
            <p>If account with this email exists, you will receive an email with instructions</p>
        </div>
        :
        <form onSubmit={handleSubmit}>
        <h3 className='hasSmallVerticalMargin'>Recover Password</h3>
        <div className='hasSmallVerticalMargin'>
            <label htmlFor="username">Email Address</label>
            <input
                type="text"
                id="username"
                autoComplete="off"
                onChange={(e) => setEmail(e.target.value)}
                value={email}
                required
            />
        </div>
            <button className='submit'>Recover</button>
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
