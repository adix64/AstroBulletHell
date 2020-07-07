using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {
    public GameObject asteroid;
    MyUIscript uiscript;
	// Use this for initialization
	void Start () {
        uiscript = GameObject.FindWithTag("UItag").GetComponent<MyUIscript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (uiscript.onPause)
            return;
        float f = Random.Range(0f, 1.0f);
        if (f > 0.9f)
        {
            GameObject.Instantiate(asteroid);
            Vector3 pos = new Vector3(Random.Range(-10f, 10f), Random.Range(2f, 10f), 0f);
            asteroid.transform.position = pos;
            float r = Random.Range(0.2f, 1.0f);
            asteroid.transform.localScale = new Vector3(r,r,r);
        }
    }
}
