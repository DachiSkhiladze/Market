import logo from './logo.svg';
import AuthorizationLayer from './Components/Authorization/AuthorizationLayer'
import { useAppSelector, useAppDispatch } from './app/hooks';
import './App.css';
import Load from './Components/LoadingAnimation/Load';
import React, { useEffect, useState } from 'react';
import Burger from './Components/menu/Burger';
import { Routes, Route } from 'react-router-dom';
import {
  decrement,
  increment,
  incrementByAmount,
  selectLoad
} from './features/counter/counterSlice';
import { selectLogged } from './Components/Authorization/reducer/logger';
import Gallery from './Components/Gallery/Gallery'
import Chat from './Components/Chat/Chat';
import Cart from './Components/Cart/Cart';

function App() {
  
  const load = useAppSelector(selectLoad);
  const logged = useAppSelector(selectLogged);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(decrement());
  }, []);

  return (
    <div className="App">
      <header className="App-header">
      </header>
        {load ? <Load /> : <></>}
        <Routes>
          {
          !logged ? 
          <Route  path="/login" element={<AuthorizationLayer />}/>  : <></>
          }
          <Route  path="/Gallery" element={<Gallery />}/>
          <Route  path="/Cart" element={<Cart />}/>
        </Routes>
        <div className='ChatContainer'>
          <Chat />
        </div>

    </div>
  );
}

export default App;
