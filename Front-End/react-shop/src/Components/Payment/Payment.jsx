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
import { useNavigate } from "react-router-dom";

const METHOD_URL = '/api/Products/GetCategories/';

const Payment = () => {
    const dispatch = useDispatch();
    const [valid, setValid]  = useState(false);
    const [price, setPrice] = useState(0);
    const [nameOnCard, setNameOnCard] = useState('');
    const [cardNumber, setCardNumber] = useState('');
    const [expiryDate, setExpiryDate] = useState('');
    const [cvc, setCVC] = useState('');
    const [value, setValue] = useState('');

    const [name, setName] = useState('');
    const [country, setCountry] = useState('');
    const [city, setCity] = useState('');

    const navigate = useNavigate();

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

    useEffect(() => {
        var month = parseInt(expiryDate.split('/')[0]);
        if(cardNumber.length > 14 && nameOnCard.length > 3 && expiryDate.length > 4 && month > 0 && month < 13 && name.length > 3 && city.length > 3 && cvc.length > 2 && country.length > 3){
            setValid(true);
        }
        else{
            setValid(false);
        }
    }, [nameOnCard, cardNumber, expiryDate, cvc, name, country, city])

    const submitPayment = async ()  => {
        dispatch(increment());
        var year = 2000 + parseInt(expiryDate.split('/')[1]);
        var month = parseInt(expiryDate.split('/')[0]);
        var body = {
            address: {
                id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                name: name,
                userId: "18477066-73a6-4885-a2ee-0b572edce2e2",
                country: country,
                city: city
                },
                paymentDetails: {
                nameOnCard: nameOnCard,
                cardNumber: cardNumber,
                month: month,
                year: year,
                cvc: cvc,
                value: price
                }
          }

        const response = await axiosAuthPost('/api/Payment/MakeOrder', body);
        console.log(response);
        dispatch(decrement());
        navigate(`/Payment/Success`);
    }

    async function GetPrice(){
        dispatch(increment());
        var response = await axiosAuthGet('/api/Payment/GetPriceForPaying');
        setPrice(response.data);
        dispatch(decrement());
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
                    <input {...getCVCProps({ onChange: ((e) => setCVC(e.target.value)) })} />
                </PaymentInputsWrapper>
                                
                <div className='MoveToCheckoutDisplay'>
                    <h3>Total Price: {price?.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")} USD</h3>
                    <button disabled={!valid} onClick={() => submitPayment()} className={valid ? 'Valid Continue' : 'Continue'}>Pay</button>
                </div>
            </div>
    </div>
  );
}

export default Payment;
