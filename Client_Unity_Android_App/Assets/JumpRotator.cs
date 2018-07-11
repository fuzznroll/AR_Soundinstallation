using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRotator : MonoBehaviour {

    int x_r;
    float x_p;
    int y_r;
    float y_p;
    int z_r;
    float z_p;

    // Use this for initialization
    void Start () {
        x_r = -90;
        y_r = 0;
        z_r = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (y_r < 360)
            y_r += 3;
        else
            y_r = 0;
        transform.rotation = Quaternion.Euler(x_r, y_r, z_r);
        y_p = (1 + Mathf.Sin(3 * Time.time)) / 50;
        transform.position = new Vector3(x_p, y_p, z_p);
    }
}
