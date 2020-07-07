using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMars : MonoBehaviour {

   
    float fx, fy;
	// Use this for initialization
	void Start () {
        fx = fy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //fx += Time.deltaTime * .05f;
        fy += Time.deltaTime * .5f;
        transform.rotation = Quaternion.EulerAngles(fx, fy, 0);
	}
}
