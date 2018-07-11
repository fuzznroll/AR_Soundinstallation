using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Vuforia;

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
    public static short A = 1234;
    public static short B = 1337;
    public static short C = 1609;
    public static short D = 1712;
}

public class NetworkingClient : MonoBehaviour {

    bool beenset1;
    bool beenset2;
    bool beenset3;
    bool beenset4;

    public GameObject IMG1;
    TrackableBehaviour Target1;
    bool Target1cState;
    bool Target1pState;
    bool Target1tState;
    public GameObject IMG2;
    TrackableBehaviour Target2;
    bool Target2cState;
    bool Target2pState;
    bool Target2tState;
    public GameObject IMG3;
    TrackableBehaviour Target3;
    bool Target3cState;
    bool Target3pState;
    bool Target3tState;
    public GameObject IMG4;
    TrackableBehaviour Target4;
    bool Target4cState;
    bool Target4pState;
    bool Target4tState;

    public GameObject ARCam;
    public GameObject MainCam;
    GameObject cam;
    public GameObject Canvas;

    NetworkClient ARClient;
    bool connectd = false;
    string IP = "192.168.178.22";

    public void SendA(bool act)
    {
        MessageA msg = new MessageA
        {
            toggle = act
        };
        ARClient.Send(MsgTypes.A, msg);
    }

    public void SendB(bool act)
    {
        MessageB msg = new MessageB
        {
            toggle = act
        };
        ARClient.Send(MsgTypes.B, msg);
    }

    public void SendC(bool act)
    {
        MessageC msg = new MessageC
        {
            toggle = act
        };
        ARClient.Send(MsgTypes.C, msg);
    }

    public void SendD(bool act)
    {
        MessageD msg = new MessageD
        {
            toggle = act
        };
        ARClient.Send(MsgTypes.D, msg);
    }

    // Use this for initialization
    void Start () {
        //SetupClient();
        cam = Instantiate(MainCam);
        Target1 = IMG1.GetComponent<TrackableBehaviour>();
        Target2 = IMG2.GetComponent<TrackableBehaviour>();
        Target3 = IMG3.GetComponent<TrackableBehaviour>();
        Target4 = IMG4.GetComponent<TrackableBehaviour>();
        Canvas.GetComponent<Canvas>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        TargetState();
    }

    void OnGUI()
    {
        if (connectd)
        {
        }
        if (!connectd)
        {
        }
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        ARClient = new NetworkClient();
        ARClient.RegisterHandler(MsgType.Connect, OnConnected);
        ARClient.RegisterHandler(MsgType.Disconnect, OnDisconnect);
        if (!ClientScene.ready)
            ARClient.Connect(IP, 4444);
    }

    void TargetState()
    {
        if (ClientScene.ready)
        {
            if (Target1.CurrentStatus == TrackableBehaviour.Status.TRACKED)
            {
                Target1cState = true;
                if (!Target1pState && !Target1tState)
                {
                    if (!beenset1)
                    {
                        SendA(Target1cState);
                        beenset1 = true;
                    }
                    Target1tState = true;
                    if (Target2tState)
                    {
                        Target2tState = false;
                        //SendB(false);
                    }
                    if (Target3tState)
                    {
                        Target3tState = false;
                        //SendC(false);
                    }
                    if (Target4tState)
                    {
                        Target4tState = false;
                        //SendD(false);
                    }
                }
            }
            if (Target1.CurrentStatus == TrackableBehaviour.Status.UNDEFINED)
                Target1cState = false;
            //Target1pState = Target1cState;

            if (Target2.CurrentStatus == TrackableBehaviour.Status.TRACKED)
            {
                Target2cState = true;
                if (!Target2pState && !Target2tState)
                {
                    if (beenset1 && !beenset2)
                    {
                        SendB(Target2cState);
                        beenset2 = true;
                    }
                    Target2tState = true;
                    if (Target1tState)
                    {
                        Target1tState = false;
                        //SendA(false);
                    }
                    if (Target3tState)
                    {
                        Target3tState = false;
                        //SendC(false);
                    }
                    if (Target4tState)
                    {
                        Target4tState = false;
                        //SendD(false);
                    }
                }
            }
            if (Target2.CurrentStatus == TrackableBehaviour.Status.UNDEFINED)
                Target2cState = false;
            //Target2pState = Target2cState;

            if (Target3.CurrentStatus == TrackableBehaviour.Status.TRACKED)
            {
                Target3cState = true;
                if (!Target3pState && !Target3tState)
                {
                    if (beenset2 && !beenset3)
                    {
                        SendC(Target3cState);
                        beenset3 = true;
                    }
                    Target3tState = true;
                    if (Target1tState)
                    {
                        Target1tState = false;
                        //SendA(false);
                    }
                    if (Target2tState)
                    {
                        Target2tState = false;
                        //SendB(false);
                    }
                    if (Target4tState)
                    {
                        Target4tState = false;
                        //SendD(false);
                    }
                }
            }
            if (Target3.CurrentStatus == TrackableBehaviour.Status.UNDEFINED)
                Target3cState = false;
            //Target3pState = Target3cState;

            if (Target4.CurrentStatus == TrackableBehaviour.Status.TRACKED)
            {
                Target4cState = true;
                if (!Target4pState && !Target4tState)
                {
                    if (beenset3 && !beenset4)
                    {
                        SendD(Target4cState);
                        beenset4 = true;
                    }
                    Target4tState = true;
                    if (Target1tState)
                    {
                        Target1tState = false;
                        //SendA(false);
                    }
                    if (Target2tState)
                    {
                        Target2tState = false;
                        //SendB(false);
                    }
                    if (Target3tState)
                    {
                        Target3tState = false;
                        //SendC(false);   
                    }
                }
            }
            if (Target4.CurrentStatus == TrackableBehaviour.Status.UNDEFINED)
                Target4cState = false;
            //Target4pState = Target4cState;
        }
        Target1pState = Target1cState;
        Target2pState = Target2cState;
        Target3pState = Target3cState;
        Target4pState = Target4cState;
    }

    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
        connectd = true;
        Destroy(cam);
        cam = Instantiate(ARCam);
        ClientScene.Ready(netMsg.conn);
        Canvas.GetComponent<Canvas>().enabled = false;
    }

    public void OnDisconnect(NetworkMessage netMsg)
    {
        Debug.Log("Disconnected from Server");
        connectd = false;
        Destroy(cam);
        cam = Instantiate(MainCam);
        Canvas.GetComponent<Canvas>().enabled = true;
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
        ARClient.Disconnect();
    }

    public void resetScene()
    {
        if (Target1tState)
            SendA(false);
        if (Target2tState)
            SendB(false);
        if (Target3tState)
            SendC(false);
        if (Target4tState)
            SendD(false);
    }

    public void Stop()
    {
        ARClient.Disconnect();
        Destroy(cam);
        cam = Instantiate(MainCam);
        Canvas.GetComponent<Canvas>().enabled = true;
    }
}


