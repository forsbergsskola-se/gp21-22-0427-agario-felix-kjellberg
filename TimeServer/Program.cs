using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

var endpoint = new IPEndPoint(
    IPAddress.Loopback,
    14411);
TcpListener tcpListener = new (endpoint);
tcpListener.Start();

var tcpClient = tcpListener.AcceptTcpClient();
new Thread(() => {
    var stream = tcpClient.GetStream();

    byte[] buffer = new byte[100];
    buffer = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
    stream.Write(buffer);
    stream.Close();
    tcpClient.Dispose();
}).Start();
