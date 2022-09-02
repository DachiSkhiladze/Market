import { useRef, useState, useEffect } from 'react';
import axios from '../api/axios';
import './Register.scss';
import { useAppSelector, useAppDispatch } from '../../app/hooks';
import {
    decrement,
    increment,
    incrementByAmount,
    selectLoad
  } from '../../features/counter/counterSlice';
import RegistrationFailure from './IncorrectRegister/RegistrationFailure';

const REGISTER_URL = '/api/User/RegisterUser';

const Register: React.FC<{setPage:any}> = ({ setPage }) => {
    const [success, setSuccess]  = useState(false);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [errMsg, setErrMsg] = useState('');
    
    const dispatch = useAppDispatch();

    useEffect(() => {
        setErrMsg('');
    }, [email, password, firstName, lastName])

    const handleSubmit = async (e:any) => {
        e.preventDefault();
        dispatch(increment());
        try {
            const model = JSON.stringify({
                "email": email,
                "password": password,
                "firstName": firstName,
                "lastName": lastName
              });
            const response = await axios.post(REGISTER_URL, model, {
                headers: {
                    'Content-Type': 'application/json'
                }}
            );
            if(response.status < 250)
            {
                console.log(JSON.stringify(response?.data));
                //const accessToken = response?.data;
                setEmail('');
                setPassword('');
                setFirstName('');
                setLastName('');
                setSuccess(true);
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
                {success ? 
                    <div className='RegistrationDoneDisplay'>
                        <h1>
                            Registration Done
                        </h1>
                        <p>
                            Please check the email for instructions of verifying the account.
                        </p>
                    </div>
                    : 
                    <div>
                            <form onSubmit={handleSubmit}>
                            <h3 className='hasSmallVerticalMargin'>Sign Up</h3>
                            <div className='hasSmallVerticalMargin'>
                                <p className=''>New to Website?
                                <button onClick={() => setPage('Login')} className='isColorBlue TransparentButton'>Sign In</button></p>
                            </div>
                            <div className='hasSmallVerticalMargin'>
                                {errMsg.length > 0 ? <RegistrationFailure /> : <></>}
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

                                <div>
                                    <div className='isLeft isAlmostHalfWidth'>
                                        <div>
                                            <label htmlFor='firstName'>First Name</label>
                                            <div className="sc-qQlgh dnZKXh">
                                                <input
                                                    type="text"
                                                    id="firstName"
                                                    onChange={(e) => setFirstName(e.target.value)}
                                                    value={firstName}
                                                    required
                                                />
                                            </div>
                                        </div>
                                    </div>
                                    <div className='isRight isAlmostHalfWidth'>
                                        <div>
                                            <label htmlFor='lastName'>Last Name</label>
                                            <div>
                                                <input
                                                    type="text"
                                                    id="lastName"
                                                    onChange={(e) => setLastName(e.target.value)}
                                                    value={lastName}
                                                    required
                                                />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                                <button style={{marginTop: '10px'}} className='submit'>Sign Up</button>
                            <p>
                                <span className="line">
                                </span>
                            </p>
                            </form>
                        </div>
                    }
                </section>
            </div>
        </div>
    );
}
export default Register;
