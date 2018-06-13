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
    public static short A = 1234;
    public static short B = 1337;
    public static short C = 1609;
    public static short D = 1712;
}

public class NetworkingServer : MonoBehaviour {

    public GameObject testPrefab;
    GameObject test;

    // Use this for initialization
    void Start ()
    {
        SetupServer();
    }
	
	// Update is called once per frame
	void Update()
    {
    }

    void OnGUI()
    {
    }

    // Create a server and listen on a port
    public void SetupServer()
    {
        NetworkServer.RegisterHandler(MsgType.Connect, OnConnected);
        NetworkServer.RegisterHandler(MsgType.Ready, OnClientReady);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnDisconnect);
        if (NetworkServer.Listen(4444))
            Debug.Log("Registering server callbacks");
        //NetworkServer.RegisterHandler(TestMsgType.StateID, OnSend);
    }

    // server function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("New Client connected: "+netMsg.conn);
    }

    public void OnDisconnect(NetworkMessage netMsg)
    {
        Debug.Log("Client disconnected: " + netMsg.conn);
        DespawnFPSC();
    }

    public void OnClientReady(NetworkMessage netMsg)
    {
        NetworkServer.SetClientReady(netMsg.conn);
        Debug.Log("Client is ready to start: " + netMsg.conn);
        NetworkServer.RegisterHandler(MsgTypes.A, OnSendA);
        NetworkServer.RegisterHandler(MsgTypes.B, OnSendB);
        NetworkServer.RegisterHandler(MsgTypes.C, OnSendC);
        NetworkServer.RegisterHandler(MsgTypes.D, OnSendD);
        SpawnFPSC();
    }

    public void OnSendA(NetworkMessage netMsg)
    {
        Debug.Log("Message received of Type [" + netMsg.msgType + "]");
        MessageA msg = netMsg.ReadMessage<MessageA>();
        if (msg.toggle)
            AkSoundEngine.PostEvent("Trigger_1", gameObject);
    }

    public void OnSendB(NetworkMessage netMsg)
    {
        Debug.Log("Message received of Type [" + netMsg.msgType + "]");
        MessageB msg = netMsg.ReadMessage<MessageB>();
        if (msg.toggle)
            AkSoundEngine.PostEvent("Trigger_2", gameObject);
    }

    public void OnSendC(NetworkMessage netMsg)
    {
        Debug.Log("Message received of Type [" + netMsg.msgType + "]");
        MessageC msg = netMsg.ReadMessage<MessageC>();
        if (msg.toggle)
            AkSoundEngine.PostEvent("Trigger_3", gameObject);
    }

    public void OnSendD(NetworkMessage netMsg)
    {
        Debug.Log("Message received of Type [" + netMsg.msgType + "]");
        MessageD msg = netMsg.ReadMessage<MessageD>();
        if (msg.toggle)
            AkSoundEngine.PostEvent("Trigger_4", gameObject);
    }

    void SpawnFPSC()
    {
        test = Instantiate(testPrefab, transform.position, transform.rotation);
    }

    void DespawnFPSC()
    {
        Destroy(test);
    }
}