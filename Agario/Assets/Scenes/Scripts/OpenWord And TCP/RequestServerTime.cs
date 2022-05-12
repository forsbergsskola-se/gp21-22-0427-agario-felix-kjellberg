using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class RequestServerTime : MonoBehaviour{
    [SerializeField] TextMeshProUGUI dateTimeText;

    public void SendRequest(){
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 14411);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 14412);
        var tcpClient = new TcpClient(clientEndpoint);
        tcpClient.Connect(serverEndpoint);

        var stream = tcpClient.GetStream();
        byte[] buffer = new byte[100];
        stream.Read(buffer, 0, 100);
        var text = Encoding.ASCII.GetString(buffer);
        dateTimeText.text = text; 
        Debug.Log("The time and date are: "+text);

        tcpClient.Close();
    }
}
