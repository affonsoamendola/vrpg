using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeerConnection
{
    /*
    public IPEndPoint ip_endpoint;
    public int ping;

    public bool waiting_for_handshake = false;
    public bool connected = false;

    //Creates a new connection to some address
    //TODO: Decide if this is the method that will attempt
    //a connection or if this just stores the information about
    //a connection
    PeerConnection()
    {

    }

    bool Connect()
    {
        byte[] packet = new byte[1024];

        packet = Encoding.ASCII.GetBytes("New Connection Request from :" + NetworkManager.instance.endpoint.ToString());
        Debug.Log("Attempting connection to ", ip_endpoint.ToString());
        Debug.Log("SEND_PACKET:" + packet);

        NetworkManager.instance.socket.Send(packet, packet.Length, ip_endpoint);
    }
}

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance = null;

    public List<Peer> targets;

    IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 25565);
    UdpClient socket = new UdpClient(this_ep);

    public Byte[] data_buffer = new Byte[1024]; 

    void Awake()
    {   
        //If theres already an instance alive
        if(instance != null)
        {
            //Dont allow for the creation of a new one
            Destroy(this);
            return;
        }

        //If instance IS null, then set it.
        instance = this;
    }

    void FixedUpdate()
    {
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        data_buffer = socket.Receive(ref sender);
    }

    //Attempts to connect to a peer
    void ConnectTo(string ip_address)
    {
        PeerConnection connection = new PeerConnection(ip_address);

        connection.Connect();

    }

    //Packs and sends the digest on the current state.
    void SendState(Peer peer)
    {

    }
*/
}

