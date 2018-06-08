using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MessageA : MessageBase
{
    public bool toggle;
}

public class MessageB : MessageBase
{
    public bool toggle;
}

public class MessageC : MessageBase
{
    public bool toggle;
}

public class MessageD : MessageBase
{
    public bool toggle;
}

public class MsgTypes
{
    public static short A = 1337;
    public static short B = 1234;
    public static short C = 1609;
    public static short D = 1712;
}

public class NetworkingClient : MonoBehaviour {

    private UnityEngine.UI.Toggle toggleA;
    private UnityEngine.UI.Toggle toggleB;
    private UnityEngine.UI.Toggle toggleC;
    private UnityEngine.UI.Toggle toggleD;

    public bool isAtStartup = true;
    NetworkClient myClient;
    bool connectd = false;
    string IP = "";

    public GameObject Cam;

    public GameObject Toggle1;
    public GameObject Toggle2;
    public GameObject Toggle3;
    public GameObject Toggle4;

    public Color dimYellow = new Color(.5F, .5F, 0F, 1F);
    public Color dimGreen = new Color(0F, .5F, 0F, 1F);
    public Color dimRed = new Color(.5F, 0F, 0F, 1F);

    public void SendA(bool act)
    {
        MessageA msg = new MessageA
        {
            toggle = act
        };
        myClient.Send(MsgTypes.A, msg);
    }

    public void SendB(bool act)
    {
        MessageB msg = new MessageB
        {
            toggle = act
        };
        myClient.Send(MsgTypes.B, msg);
    }

    public void SendC(bool act)
    {
        MessageC msg = new MessageC
        {
            toggle = act
        };
        myClient.Send(MsgTypes.C, msg);
    }

    public void SendD(bool act)
    {
        MessageD msg = new MessageD
        {
            toggle = act
        };
        myClient.Send(MsgTypes.D, msg);
    }

    // Use this for initialization
    void Start () {
        Cam.GetComponent<Camera>().backgroundColor = dimYellow;
        toggleA = Toggle1.GetComponent<UnityEngine.UI.Toggle>();
        toggleB = Toggle2.GetComponent<UnityEngine.UI.Toggle>();
        toggleC = Toggle3.GetComponent<UnityEngine.UI.Toggle>();
        toggleD = Toggle4.GetComponent<UnityEngine.UI.Toggle>();
        toggleA.onValueChanged.AddListener(OnToggleA);
        toggleB.onValueChanged.AddListener(OnToggleB);
        toggleC.onValueChanged.AddListener(OnToggleC);
        toggleD.onValueChanged.AddListener(OnToggleD);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnGUI()
    {
        if (connectd)
        {
            //Cam.GetComponent<Camera>().backgroundColor = dimGreen;
        }
        if (!connectd)
        {
            //Cam.GetComponent<Camera>().backgroundColor = dimRed;
        }
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(MsgType.Disconnect, OnDisconnect);
        if (!ClientScene.ready)
            myClient.Connect(IP, 4444);
        isAtStartup = false;
    }


    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
        connectd = true;
        ClientScene.Ready(netMsg.conn);
        Cam.GetComponent<Camera>().backgroundColor = dimGreen;
    }

    public void OnDisconnect(NetworkMessage netMsg)
    {
        Debug.Log("Disconnected from Server");
        connectd = false;
        Cam.GetComponent<Camera>().backgroundColor = dimRed;
    }

    void OnToggleA(bool isOn)
    {
        SendA(isOn);
    }

    void OnToggleB(bool isOn)
    {
        SendB(isOn);
    }

    void OnToggleC(bool isOn)
    {
        SendC(isOn);
    }

    void OnToggleD(bool isOn)
    {
        SendD(isOn);
    }

    public void getIP(string ip)
    {
        IP = ip;       
    }

    public void disconnect()
    {
        myClient.Disconnect();
        Cam.GetComponent<Camera>().backgroundColor = dimRed;
    }
}


