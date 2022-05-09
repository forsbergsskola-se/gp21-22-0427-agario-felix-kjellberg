
using System.Net;
using System.Net.Sockets;

var udpClient = new UdpClient();
var remoteEP = new IPEndPoint(
    IPAddress.Any, 11000);
var data = udpClient.Receive(ref remoteEP);
udpClient.Connect(remoteEP);

