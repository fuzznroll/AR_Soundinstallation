using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    int x_r;
    int y_r;
    int z_r;

	// Use this for initialization
	void Start () {
        x_r = -90;
        y_r = 0;
        z_r = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (y_r < 360)
            y_r+=2;
        else
            y_r = 0;
        transform.rotation = Quaternion.Euler(x_r,y_r,z_r);
	}
}
