import logo from './logo.svg';
import { Counter } from './features/counter/Counter';
import AuthorizationLayer from './Components/Authorization/AuthorizationLayer'
import { useAppSelector, useAppDispatch } from './app/hooks';
import './App.css';
import Load from './Components/LoadingAnimation/Load';
import React, { useEffect, useState } from 'react';
import {
  decrement,
  increment,
  incrementByAmount,
  selectLoad
} from './features/counter/counterSlice';

function App() {
  
  const load = useAppSelector(selectLoad);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(decrement());
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        {load ? <Load /> : <></>}
        <AuthorizationLayer />
      </header>
    </div>
  );
}

export default App;
