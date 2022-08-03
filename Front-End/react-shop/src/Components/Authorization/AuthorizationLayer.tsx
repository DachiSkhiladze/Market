import Login from '../Authorization/Login';
import { useEffect, useState } from 'react';
import Register from '../Authorization/Register';

function App() {
    const [page, setPage] = useState('Login');
    
  return (
    <div className="App">
      <header className="App-header">
        {page === "Register" ? <Register setPage = {setPage}/> : <Login setPage = {setPage}/>}
      </header>
    </div>
  );
}

export default App;
