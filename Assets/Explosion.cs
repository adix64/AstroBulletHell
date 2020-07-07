using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    float t = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime;
        if (t > 1f)
            GameObject.Destroy(this.gameObject);
    }
}
