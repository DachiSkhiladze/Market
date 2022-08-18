import React, { useState, useEffect, useRef } from 'react';
import { DefaultHttpClient, HttpRequest, HttpResponse, HubConnectionBuilder, HttpTransportType } from '@microsoft/signalr';
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
    const [ connection, setConnection ] : any = useState(null);
    const [ chat, setChat ] = useState([]);
    const latestChat:any = useRef(null);

    latestChat.current = chat;

    useEffect(() => {
        var tkn = localStorage.getItem('token')!;
        var token = JSON.parse(tkn);
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7223/hubs/chat', { httpClient: new CustomHttpClient(), transport: HttpTransportType.LongPolling}, )
            .withAutomaticReconnect()
            .build();
        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('Connected!');
                    connection.on('ReceiveMessage', (message: any) => {
                        const updatedChat:any = [...latestChat.current];
                        updatedChat.push(message);
                    
                        setChat(updatedChat);
                    });
                })
                .catch((e: any) => console.log('Connection failed: ', e));
            }
    }, [connection]);

    const sendMessage = async (user:any, message:any) => {
        const chatMessage = {
            MessageTo: user,
            message: message
        };

        try {
            var tkn = localStorage.getItem('token')!;
            var token : any = JSON.parse(tkn);
            await connection.send('SendMessage', chatMessage);
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