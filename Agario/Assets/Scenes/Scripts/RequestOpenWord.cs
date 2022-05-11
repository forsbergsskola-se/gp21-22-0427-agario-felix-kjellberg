using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

public class RequestOpenWord : MonoBehaviour{
    public TextField textField;
    
    public void SendWordToServer(){
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 14411);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 15511);

        var client = new UdpClient(clientEndpoint);

        var message = Encoding.ASCII.GetBytes("Hello!");

        client.Send(message,message.Length, serverEndpoint);
    }
}
