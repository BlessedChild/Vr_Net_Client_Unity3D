using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Login : MonoBehaviour {

    Thread connectServer;
    static byte[] buffer = null;
    static byte[] recbuffer = new byte[4];

    private void Start()
    {
        connectServer = new Thread(initGame);      
    }

    public void SingIn()
    {
        connectServer.Start();
    }

    public void CreatID()
    {

    }

    public void GetbackIDorPassword()
    {

    }

    private void initGame()
    {
        string ip = "127.0.0.1";
        IPAddress ipAddress = IPAddress.Parse(ip);
        Socket a = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        a.Connect(ip, 6666);


        if(a.Connected)
        {
            Thread newsend = new Thread(Login.sendmsg);
            newsend.Start(a);

            Thread newaccept = new Thread(Login.acceptmsg);
            newaccept.Start(a);




            /*
            int count = a.Receive(recbuffer, recbuffer.Length, 0);

            if(count > 0)
            {
                Debug.Log(networkre.pcak.ByteArraytoInt(recbuffer));
            }
            */
        }
        else
        {
            Debug.Log("connect faile");
            a.Close();
        }
    }

    public static void sendmsg(object s)
    {
        int timei = 0;
        while(true)
        {
            if (timei < 88888)
            {
                buffer = networkre.pcak.InttoByteArray(timei);
                Socket b = (Socket)s;
                b.Send(buffer, buffer.Length, SocketFlags.None);

                Debug.Log("FromClient: send to server: " + timei++);
                Thread.Sleep(50);
            }
        }
    }

    public static void acceptmsg(object s)
    {
        Socket a = (Socket)s;
        while (true)
        {
            int count = a.Receive(recbuffer, recbuffer.Length, 0);

            if (count > 0)
            {
                Debug.Log(networkre.pcak.ByteArraytoInt(recbuffer));
            }
        }
    }


}
