import AuthorizationLayer from './Components/Authorization/AuthorizationLayer';
import { useAppSelector, useAppDispatch } from './app/hooks';
import './App.css';
import Load from './Components/LoadingAnimation/Load';
import React, { useEffect, useState } from 'react';
import { Routes, Route } from 'react-router-dom';
import {
  decrement,
  increment,
  selectLoad,
} from './features/counter/counterSlice';
import { logIn, selectLogged } from './Components/Authorization/reducer/logger';
import Gallery from './Components/Gallery/Gallery'
import Cart from './Components/Cart/Cart';
import Header from './Header';
import { axiosAuthGet } from './Components/api/axios';

function App() {
  const load = useAppSelector(selectLoad);
  const logged = useAppSelector(selectLogged);
  const dispatch = useAppDispatch();
  const [isLogged, setIsLogged] : any = useState(false);
  async function IsLogged(){
    var response =  await axiosAuthGet('/api/User/IsLogged');
    if(response?.status < 240){
      console.log("Logged");
      setIsLogged(true);
      dispatch(logIn());
    }
  }

  useEffect(() => {
    dispatch(decrement());
    IsLogged();
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        <Header isLogged={isLogged} setIsLogged = {setIsLogged}/>
      </header>
        {load ? <Load /> : <></>}
        <div className='MainCointainer'>
          <Routes>
            {
            (!isLogged) ? 
            <Route  path="/login" element={<AuthorizationLayer />}/>  : <></>
            }
            <Route  path="/Gallery" element={<Gallery />}/>
            <Route  path="/Cart" element={<Cart />}/>
            <Route path='*' element={<Gallery />}/>
          </Routes>
        </div>
        <div className='ChatContainer'>
        </div>

    </div>
  );
}

export default App;
