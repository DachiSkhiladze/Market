import React from 'react';

import Message from './Message';

const ChatWindow = (props:any) => {
    const chat:any = props.chat
        .map((m: { user: any; message: any; }) => <Message 
            key={Date.now() * Math.random()}
            user={m.user}
            message={m.message}/>);

    return(
        <div>
            {chat}
        </div>
    )
};

export default ChatWindow;