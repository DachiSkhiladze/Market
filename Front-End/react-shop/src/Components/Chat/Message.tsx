import React from 'react';

const Message = (props:any) => (
    <div className='MessageBox' style={{ background: "#eee", borderRadius: '5px', padding: '0 10px' }}>
        {props.message}
    </div>
);

export default Message;