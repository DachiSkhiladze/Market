import './Payment.scss';


const METHOD_URL = '/api/Products/GetCategories/';

const Success = () => {
    return (
    <div className="Success">
        <h1>Success</h1>
        <h2>You will receive receipt on the email!</h2>
    </div>
  );
}

export default Success;
