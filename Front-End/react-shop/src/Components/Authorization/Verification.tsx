import { useAppSelector, useAppDispatch } from '../../app/hooks';
import './Verification.scss';
import axios from '../api/axios';
import React, { useEffect, useState } from 'react';
import {
  decrement,
  increment,
  incrementByAmount,
  selectLoad
} from '../../features/counter/counterSlice';

const CONFIRM_URL = '/User/ConfirmEmail';

const Verification: React.FC<{code:any}> = ({ code }) => {

  const load = useAppSelector(selectLoad);
  const dispatch = useAppDispatch();
  const [confirm, setConfirm] = useState<boolean | null>(false);

  useEffect(() => {

    dispatch(increment());
    async function SendConfirmationCode(){
      try{
        const response = await axios.get(CONFIRM_URL + `/${code}`, {
          headers: {
              'Content-Type': 'application/json'
          }}
      )
        setConfirm(response?.status < 250);
        dispatch(decrement());
      }
      catch(e:any){
        dispatch(decrement());
      }
    }

    SendConfirmationCode();
  }, []);

  return (
    <div className="Verification">
        {confirm === true ?
        <div>
            <h1 className='VerificationResult isColorBlue isTextCentered'>Confirmed</h1>
            <p className='isTextCentered'>Email successfully verified. Now you can enter in the system.</p>
        </div>
                : 
                <div>
                    <h1 className='VerificationResult isColorBlue isTextCentered'>Outdated URL</h1>
                    <p className='isTextCentered'>Email is not verified. Probably the link is expired. Please contact support for more information.</p>
                </div>
            }
    </div>
  );
}

export default Verification;
