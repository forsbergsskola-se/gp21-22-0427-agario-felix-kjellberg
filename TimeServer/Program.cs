using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

var endpoint = new IPEndPoint(
    IPAddress.Loopback,
    14411);
TcpListener tcpListener = new (endpoint);
tcpListener.Start();


var tcpClient = tcpListener.AcceptTcpClient();

tcpListener.Stop();

byte[] buffer = new byte[100];
buffer = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
if (tcpClient != null) tcpClient.GetStream().Write(buffer);
tcpClient.GetStream().Close();
tcpClient.Close();