using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AR_State : MonoBehaviour {

    public GameObject IMG;
    TrackableBehaviour target;

	// Use this for initialization
	void Start () {
        target = IMG.GetComponent<TrackableBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        targetState();
	}

    void targetState()
    {
        if(target.CurrentStatus==TrackableBehaviour.Status.TRACKED)
        Debug.Log(target.CurrentStatus);
    }
}
