using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingAndroid : MonoBehaviour {

    public bool isAtStartup = true;
    NetworkClient myClient;
    bool connectd = false;

	// Use this for initialization
	void Start () {
        SetupClient();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (connectd)
        {
            GUI.Label(new Rect(2, 10, 150, 100), "connected");
        }
    }

    // Create a server and listen on a port
    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        isAtStartup = false;
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("192.168.1.247", 4444);
        isAtStartup = false;
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
    }

    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
        connectd = true;
    }
}


