import { useNavigate } from 'react-router-dom';
import './Header.scss';

import { logIn, selectLogged } from './Components/Authorization/reducer/logger';
import { useAppSelector } from './app/hooks';
const Header : React.FC<{isLogged:any, setIsLogged:any}> = ({ isLogged, setIsLogged}) => {
    let navigate = useNavigate();
    const logged = useAppSelector(selectLogged);

    const logout = async () => {
        localStorage.removeItem("token")
        setIsLogged(false);
        navigate('/login');
        console.log("asd");
    }

  return (
    <nav className="nav">
        <div className="container">
            <div className="logo">
                <a href="#">Ticket Shop</a>
            </div>
            <div id="mainListDiv" className="main_list">
                <ul className="navlinks">
                    <li><a href="/Gallery">Gallery</a></li>
                    
                    {logged ?
                    <>
                        <li><a href="/">Chat</a></li>
                        <li><a href="/Cart">Cart</a></li>
                        <li className='LogOut'><a href='/login' onClick={logout}>Log Out</a></li>
                    </>
                     :  <li><a href="/Login">Log In</a></li>}
                </ul>
            </div>
            <span className="navTrigger">
                <i></i>
                <i></i>
                <i></i>
            </span>
        </div>
    </nav>
  );
}

export default Header;
