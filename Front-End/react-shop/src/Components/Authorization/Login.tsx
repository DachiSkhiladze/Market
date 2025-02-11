import { useRef, useState, useEffect } from 'react';
import axios from '../api/axios';
import './Login.scss';
import Verification from './Verification';
import UpdatePasswordRecovery from './UpdatePasswordRecovery'
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import { useNavigate } from "react-router-dom";
import {
    decrement,
    increment,
    incrementByAmount,
    selectLoad
  } from '../../features/counter/counterSlice';
import{
    logIn,
    logOut,
} from './reducer/logger'
import LoginFailure from './IncorrectLogin/LoginFailure';
import ForgotPassword from './ForgotPassword';
const LOGIN_URL = '/api/User/LoginUser';

const Login : React.FC<{setPage:any}> = ({ setPage }) => {

    let navigate = useNavigate();
    
    const code = (new URLSearchParams(window.location.search)).get("code");
    const token = (new URLSearchParams(window.location.search)).get("recovery");
  
    const [forgotPassword, setForgotPassword] = useState(false);

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [errMsg, setErrMsg] = useState('');

    const dispatch = useAppDispatch();

    useEffect(() => {
        setErrMsg('');
    }, [email, password])

    const handleSubmit = async (e:any) => {
        e.preventDefault();
        dispatch(increment());
        try {
            const model = JSON.stringify({
                "email": email,
                "password": password
              });
            const response = await axios.post(LOGIN_URL, model, {
                headers: {
                    'Content-Type': 'application/json'
                }}
            )
            if(response.status < 250)
            {
                const tokenObject = response?.data;
                setEmail('');
                setPassword('');
                localStorage.setItem('token', JSON.stringify(tokenObject));
                console.log(tokenObject);
                dispatch(logIn());
                navigate("/Gallery", { replace: true });
                window.location.reload();
            }
            else{
                setErrMsg('Success');
            }
        } catch (err:any) {
            if (!err?.response) {
                setErrMsg('No Server Response');
            } else if (err.response?.status === 400) {
                setErrMsg('Missing Username or Password');
            } else if (err.response?.status === 401) {
                //setErrMsg('Unauthorized');
                setErrMsg('Login Failed');
            } else {
                setErrMsg('Login Failed');
            }
        }
        dispatch(decrement());
    }

    return (
        <div className='rootDisplay'>
            <div className='loginContainer'>
                <section className='bannerDisplay'>
                    
                </section>
                <section className='loginFormDisplay'>
                    {
                    token === null ?
                    forgotPassword ? 
                    <ForgotPassword /> 
                    : code === null ? 
                    <div>
                        <form onSubmit={handleSubmit}>
                        <h3 className='hasSmallVerticalMargin'>Sign In</h3>
                        <div className='hasSmallVerticalMargin'>
                            <p className=''>New to Website?
                            <button onClick={() => setPage('Register')} className='isColorBlue TransparentButton'>Sign Up</button></p>
                        </div>
                        <div className='hasSmallVerticalMargin'>
                            {errMsg.length > 0 ? <LoginFailure /> : <></>}
                            <label htmlFor="username">Email Address</label>
                            <input
                                type="text"
                                id="username"
                                autoComplete="off"
                                onChange={(e) => setEmail(e.target.value)}
                                value={email}
                                required
                            />

                            <label htmlFor="password">Password</label>
                            <input
                                type="password"
                                id="password"
                                onChange={(e) => setPassword(e.target.value)}
                                value={password}
                                required
                            />
                        </div>
                            <button onClick={() => setForgotPassword(true)} className='hasSmallVerticalMargin TransparentButton isRight isColorBlue'>Forgot Password?</button>

                            <button className='submit'>Sign In</button>
                        <p>
                            <span className="line">
                            </span>
                        </p>
                        </form>
                    </div>
                    :
                    <Verification code={code}/>
                    :
                    <UpdatePasswordRecovery token={token} />
                    }
                </section>
            </div>
        </div>
    );
}
export default Login;
