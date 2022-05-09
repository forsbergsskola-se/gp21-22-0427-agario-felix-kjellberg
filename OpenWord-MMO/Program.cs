
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 14411);

var server = new UdpClient(serverEndpoint);

while (true){
    IPEndPoint clientEndPoint = default;
    var data = server.Receive(ref clientEndPoint);
    Console.WriteLine($"packet received from: {clientEndPoint} saying: {Encoding.ASCII.GetString(data)}");
}
