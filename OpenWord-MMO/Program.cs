
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 14411);

var server = new UdpClient(serverEndpoint);
Regex regex = new Regex(@"^\S{0,20}$");
string text = "";

while (true){
    IPEndPoint clientEndPoint = default;
    var data = server.Receive(ref clientEndPoint);
    var clientText = Encoding.ASCII.GetString(data);
    var errorMessage = Encoding.ASCII.GetBytes("ERROR! Message is either over 20 characters or contains wide space, try again");
    
    Console.WriteLine($"packet received from: {clientEndPoint} saying: {clientText}");
    
    if (!regex.IsMatch(clientText))
        server.Send(errorMessage, clientEndPoint);
    
    if (regex.IsMatch(clientText)){
        text += clientText + " ";
        var dataText = Encoding.ASCII.GetBytes(text);
        server.Send(dataText, clientEndPoint);
    }
}
