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

        
            int port = 8000;
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            try
            {
                clientSocket.Connect(ipe);
            /*      Thread t = new Thread(RecieveNumber);
                  t.Start();*/
            StartCoroutine("RecieveOrders");
            }
            catch (Exception)
            {
                Debug.Log("Kunne ikke opnå forbindelse");
                
                throw;
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

    public IEnumerator RecieveOrders()
    {
        NetworkStream nstream = new NetworkStream(clientSocket);

        StreamReader reader = new StreamReader(nstream);
        while (true)
        {
            string input;
            
            if (nstream.DataAvailable)
            {
       
                input = reader.ReadLine();
                Debug.Log(input);
                if (input.Contains("St"))
                {
                    string[] sd = input.Split(';');
                    //Metodenavn
                    //Hastighed
                    gameObject.BroadcastMessage(sd[0], Int32.Parse(sd[1]));
                    Debug.Log(sd[0] + " " + sd[1]);

                }
                yield return new WaitForSeconds(0.1f);

            }
            yield return new WaitForSeconds(0.1f);

        }
    }

    public void RecieveNumber()
    {
        NetworkStream nstream = new NetworkStream(clientSocket);
        
        StreamReader reader = new StreamReader(nstream);
        while (true)
        {
            string input = reader.ReadLine();

            Debug.Log(input);

            if (input.Contains("St") )
            {
                string[] sd = input.Split(';');
                //Metodenavn
                //Hastighed

           
                

                gameObject.BroadcastMessage(sd[0],sd[1]);
            }
            Thread.Sleep(500);
        }
        if (useGUILayout)
        {
            
        }


        reader.Close();
        reader.Dispose();
    }

    void Update () {
        if (Input.GetKeyUp("l"))
        {
            ConnectToClient();
        }
	}
}
