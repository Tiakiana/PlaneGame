using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Connection : MonoBehaviour
{
    public InputField Inputs;
    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    void Start ()
    {
    }



   

    public void ConnectToClient()
    {
        TcpClient tcpClient = new TcpClient();

        if (Inputs.text!=null)
        {
            int port = 8000;
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(Inputs.text), port);
            try
            {
                clientSocket.Connect(ipe);
                Thread t = new Thread(RecieveNumber);
                t.Start();
            }
            catch (Exception)
            {
                Debug.Log("Kunne ikke opnå forbindelse");
                
                throw;
            }
        }
    }

    public void SendReady()
    {
        NetworkStream nstream = new NetworkStream(clientSocket);

        StreamWriter writer = new StreamWriter(nstream);
        writer.Write("True");
        
           
        writer.Flush();
        writer.Write("1;Straight;2;True");
        writer.Flush();
        writer.Close();
        writer.Dispose();

    }

    public void RecieveNumber()
    {
        NetworkStream nstream = new NetworkStream(clientSocket);
        
        StreamReader reader = new StreamReader(nstream);
      
        while (true)
        {
            Debug.Log(reader.ReadLine());
            Thread.Sleep(500);
        }
        reader.Close();
        reader.Dispose();
    }

    void Update () {
	
	}
}
