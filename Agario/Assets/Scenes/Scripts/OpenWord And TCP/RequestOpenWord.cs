using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class RequestOpenWord : MonoBehaviour{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI TMP;
    
    public void SendWordToServer(){
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 14411);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 15511);

        var client = new UdpClient(clientEndpoint);

        var message = Encoding.ASCII.GetBytes(inputField.text);

        client.Send(message, message.Length, serverEndpoint);
        var serverResponseText = Encoding.ASCII.GetString(client.Receive(ref serverEndpoint));
        TMP.text = serverResponseText;
    }
}
