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
import { logAdmin, logEmployee, logIn, selectLogged } from './Components/Authorization/reducer/logger';
import Gallery from './Components/Gallery/Gallery'
import Cart from './Components/Cart/Cart';
import Header from './Header';
import { axiosAuthGet } from './Components/api/axios';
import Payment from './Components/Payment/Payment';
import Success from './Components/Payment/Success';
import Fail from './Components/Payment/Fail';
import CreateProduct from './AdminComponents/CreateProduct';
import CreateCategory from './AdminComponents/CreateCategory';
import CreateSubCategory from './AdminComponents/CreateSubCategory';
import Products from './AdminComponents/Products';
import UpdateProduct from './AdminComponents/UpdateProduct';
import Categories from './AdminComponents/Categories';
import SubCategoriesList from './AdminComponents/SubCategoriesList';
import Users from './AdminComponents/Users';
import Orders from './EmployeeComponents/Orders';

function App() {
  const load = useAppSelector(selectLoad);
  const logged = useAppSelector(selectLogged);
  const dispatch = useAppDispatch();
  const [isLogged, setIsLogged] : any = useState(false);

  async function IsLogged(){
    var response =  await axiosAuthGet('/api/User/IsLogged');
    if(response?.status < 240){
      setIsLogged(true);
      dispatch(logIn());
    }
  }

  async function IsEmployee(){
    var response =  await axiosAuthGet('/api/Employee/IsEmployee');
    if(response?.status < 240){
      setIsLogged(true);
      dispatch(logEmployee());
    }
  }

  async function IsAdmin(){
    var response =  await axiosAuthGet('/api/Admin/IsAdmin');
    if(response?.status < 240){
      setIsLogged(true);
      dispatch(logAdmin());
    }
  }

  useEffect(() => {
    dispatch(decrement());
    IsLogged();
    IsEmployee();
    IsAdmin();
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
            (logged === 'Visitor') ? 
              <Route  path="/login" element={<AuthorizationLayer />}/>  :
            <>
                <Route  path="/Cart" element={<Cart />}/>
                {
                  (logged === 'Employee') ? 
                    <Route  path="/Orders" element={<Orders /> } />
                    :
                    <>
                    </>
                }
            </>
            }
            {
              (logged === 'Administrator') ? 
              <>
                <Route  path="/Orders" element={<Orders />}/>
                <Route  path="/CreateProduct" element={<CreateProduct />}/>
                <Route  path="/Users" element={<Users />}/>
                <Route  path="/Products" element={<Products />}/>
                <Route  path="/Categories" element={<Categories /> } />
                <Route  path="/SubCategories" element={<SubCategoriesList />}/>
                <Route  path="/CreateCategory" element={<CreateCategory />}/>
                <Route  path="/CreateSubCategory" element={<CreateSubCategory />}/>

                <Route  path="/UpdateProduct/:id" element={<UpdateProduct /> } />

              </>
              :
              <>
              </>
            }
            
            <Route path="/Payment/Success" element={<Success />}/>
            <Route path="/Payment/Fail" element={<Fail />}/>
            <Route path="/Payment" element={<Payment />}/>
            <Route path="/Gallery" element={<Gallery />}/>
            <Route path='*' element={<Gallery />}/>
          </Routes>
        </div>
        <div className='ChatContainer'>
        </div>

    </div>
  );
}

export default App;
