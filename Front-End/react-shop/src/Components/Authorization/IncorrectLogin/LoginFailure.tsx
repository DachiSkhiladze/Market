import logo from './logo.svg';
import './LoginFailure.scss';

function LoginFailure() {
  return (
    <div className="LoginFailure">
        <div className='LoginFailureDisplay'>
            <div className='isLeft'>
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24"><g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd"><path fill="#d93a3a" d="M12.5099477,22.7984661 L22.8001703,12.4714008 C23.0597259,12.210916 23.0593493,11.7894555 22.7993286,11.5294349 L12.4705801,1.20068785 C12.2102306,0.94033836 11.7881206,0.94033836 11.5277711,1.20068785 L1.2007044,11.5277531 C0.940354857,11.7881026 0.940354829,12.2102126 1.20070434,12.4705621 C1.20098417,12.4708419 1.20126424,12.4711215 1.20154457,12.4714008 L11.5671402,22.8001509 C11.8279529,23.0600364 12.2500623,23.0592847 12.5099478,22.798472 C12.5099487,22.798471 12.5099497,22.79847 12.5099507,22.7984691 Z"></path><ellipse fill="#FFFFFF" cx="11.999663" cy="17.5553259" rx="1" ry="1"></ellipse><path d="M11.999663,14.6142705 L11.999663,14.6142705 C12.5410964,14.6142705 12.9800149,14.175352 12.9800149,13.6339187 L12.9800149,7.09824024 C12.9800149,6.55680687 12.5410964,6.1178884 11.999663,6.1178884 L11.999663,6.1178884 C11.4582297,6.1178884 11.0193112,6.55680687 11.0193112,7.09824024 L11.0193112,13.6339187 C11.0193112,14.175352 11.4582297,14.6142705 11.999663,14.6142705 Z" fill="#FFFFFF"></path></g></svg>
            </div>
            <div style={{width: '90%'}} className='isRight'>
                <span className='Error'>We can’t find an account with that email and password combination Or you have not verified your email address.</span>
                <div className='Warning'>
                Please double check your entry and try again.
                To keep your account secure only 
                5 more incorrect sign in attempts are allowed.
                        <button className='isColorBlue TransparentButton'>Request a new one to continue</button>
                </div>
            </div>
        </div>
    </div>
  );
}

export default LoginFailure;
