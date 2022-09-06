import './Payment.scss';


const METHOD_URL = '/api/Products/GetCategories/';

const Fail = () => {
    return (
        <div className="Fail">
            <h1>Payment Failed</h1>
            <h2>Please check your card details and try again!</h2>
        </div>
  );
}

export default Fail;
