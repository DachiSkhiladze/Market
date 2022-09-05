import React, { useEffect, useState } from 'react';
import { axiosAuthGet, axiosAuthPost } from '../api/axios';
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
    const [expiryDate, setExpiryDate] = useState('');
    const [cvc, setCVC] = useState('');
    const [value, setValue] = useState('');

    const [name, setName] = useState('');
    const [country, setCountry] = useState('');
    const [city, setCity] = useState('');



    const {
        meta,
        wrapperProps,
        getCardImageProps,
        getCardNumberProps,
        getExpiryDateProps,
        getCVCProps
      } = usePaymentInputs();

    useEffect(() => {
        GetPrice();
    }, []);

    const submitPayment = async ()  => {
        var body = {
            address: {
                id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                name: "string",
                userId: "18477066-73a6-4885-a2ee-0b572edce2e2",
                country: "string",
                city: "string"
                },
                paymentDetails: {
                nameOnCard: "string",
                cardNumber: "string",
                month: 0,
                year: 0,
                cvc: "string",
                value: 0
                }
          }

        var response = await axiosAuthPost('/api/Payment/MakeOrder', body);
    }

    async function GetPrice(){
        var response = await axiosAuthGet('/api/Payment/GetPriceForPaying');
        setPrice(response.data);
    }

    return (
    <div className="PaymentDisplay">
        <div className='AddressDisplay'>
            <h3>Address Details</h3>
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
                <input maxLength={19} {...getCardNumberProps({ onChange: ((e) => setCardNumber(e.target.value)) })}/>
                <input {...getExpiryDateProps({ onChange: ((e) => setExpiryDate(e.target.value)) })} />
                <input {...getCVCProps({ onChange: ((e) => setExpiryDate(e.target.value)) })} />
            </PaymentInputsWrapper>
                            
            <div className='MoveToCheckoutDisplay'>
                <h3>Total Price: {price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
            <button onClick={() => submitPayment()} className='Continue'>Pay</button>
        </div>
        </div>

    </div>
  );
}

export default Payemnt;
