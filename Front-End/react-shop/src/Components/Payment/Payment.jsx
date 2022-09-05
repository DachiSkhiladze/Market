import React, { useEffect, useState } from 'react';
import { axiosAuthGet, axiosGet } from '../api/axios';
import './Payment.scss';
import { PaymentInputsWrapper, usePaymentInputs } from 'react-payment-inputs';
import images from 'react-payment-inputs/lib/images';
import {
    decrement,
    increment
  } from '../../features/counter/counterSlice';
import { useDispatch } from 'react-redux';


const METHOD_URL = '/api/Products/GetCategories/';

const Payemnt = () => {
    const dispatch = useDispatch();
    const [success, setSuccess]  = useState(false);
    const [price, setPrice] = useState(0);
    const [nameOnCard, setNameOnCard] = useState('');
    const [cardNumber, setCardNumber] = useState('');
    const [month, setMonth] = useState('');
    const [year, setYear] = useState('');
    const [cvc, setCVC] = useState('');
    const [value, setValue] = useState('');

    const [name, setName] = useState('');
    const [country, setCountry] = useState('');
    const [city, setCity] = useState('');

    const {
        wrapperProps,
        getCardImageProps,
        getCardNumberProps,
        getExpiryDateProps,
        getCVCProps
      } = usePaymentInputs();

    useEffect(() => {
        GetPrice();
    }, [])

    async function GetPrice(){
        var response = await axiosAuthGet('/api/Payment/GetPriceForPaying');
        setPrice(response.data);
    }

    return (
    <div className="PaymentDisplay">
        <div className='AddressDisplay'>
            <h3>Address</h3>
            <label>Country</label>
            <input
                className='inp'
                type="text"
                id="username"
                autoComplete="off"
                onChange={(e) => setCountry(e.target.value)}
                value={country}
                required
                />
                
            <label>City</label>
            <input
                className='inp'
                type="text"
                id="username"
                autoComplete="off"
                onChange={(e) => setCity(e.target.value)}
                value={city}
                required
                />

            <label>Street & Floor</label>
            <input
                className='inp'
                type="text"
                id="username"
                autoComplete="off"
                onChange={(e) => setName(e.target.value)}
                value={name}
                required
                />  
        </div>
        <div className='PaymentDisplay'>
            <h3>Payment Details</h3>
            <label>Name On The Card</label>
            <input
                className='inp'
                type="text"
                id="username"
                autoComplete="off"
                onChange={(e) => setNameOnCard(e.target.value)}
                value={nameOnCard}
                required
                />
            <label>Details</label>
            <PaymentInputsWrapper className="CardInput" {...wrapperProps}>
                <svg {...getCardImageProps({ images })} />
                <input maxLength={19} {...getCardNumberProps()} />
                <input {...getExpiryDateProps()} />
                <input {...getCVCProps()} />
            </PaymentInputsWrapper>
                            
            <div className='MoveToCheckoutDisplay'>
                <h3>Total Price: {price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
            <button className='Continue'>Proceed Payment</button>
        </div>
        </div>

    </div>
  );
}

export default Payemnt;
