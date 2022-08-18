import React, { useState, useEffect, useRef } from 'react';
import { DefaultHttpClient, HttpRequest, HttpResponse, HubConnectionBuilder } from '@microsoft/signalr';
import './Chat.scss';
import ChatWindow from './ChatWindow';
import ChatInput from './ChatInput';
import axios from 'axios';

class CustomHttpClient extends DefaultHttpClient {
    constructor() {
        super(console); // the base class wants an signalR.ILogger, I'm not sure if you're supposed to put *the console* into it, but I did and it seemed to work
      }

    public send(request: HttpRequest): Promise<HttpResponse> {
        var tkn = localStorage.getItem('token')!;
        var token = JSON.parse(tkn);
        request.headers = { ...request.headers, 'Authorization': 'Bearer ' + token.accessToken };
        return super.send(request);
    }
}

const Chat = () => {
    const [ chat, setChat ] = useState([]);
    const latestChat:any = useRef(null);

    latestChat.current = chat;

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:7223/hubs/chat', { httpClient: new CustomHttpClient() })
            .withAutomaticReconnect()
            .build();

        connection.start()
        .then(async result => {
            console.log('Connected!');
            await connection.send('Subscribe');
            connection.on('ReceiveMessage', message => {
                const updatedChat:any = [...latestChat.current];
                updatedChat.push(message);
            
                setChat(updatedChat);
            });
        })
        .catch(e => console.log('Connection failed: ', e));
    }, []);

    const sendMessage = async (user:any, message:any) => {
        const chatMessage = {
            user: user,
            message: message
        };

        try {
            var tkn = localStorage.getItem('token')!;
            var token : any = JSON.parse(tkn);
            await  fetch('https://localhost:7223/api/chat/messages', { 
                method: 'POST', 
                body: JSON.stringify(chatMessage),
                headers: {                
                    'Authorization': 'Bearer ' + token.accessToken,
                    'Content-Type': 'application/json',
                }
            });
        }
        catch(e) {
            console.log('Sending message failed.', e);
        }
    }

    return (
        <div>
            <hr />
            <div className='ConversationContainer'>
                <ChatWindow chat={chat}/>
            </div>
            <ChatInput sendMessage={sendMessage} />

        </div>
    );
};

export default Chat;