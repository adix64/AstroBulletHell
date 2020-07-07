using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour {
    public Vector3 startPoint;
    public Vector3 trajectory;
    public float t = 0f;
    public Rigidbody rbody;
	// Use this for initialization
	void Start ()
    {
        rbody = GetComponent<Rigidbody>();
	}
    IEnumerator Autodestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
    void OnCollisionEnter(Collision col)
    {
        GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(Autodestroy());
    }
    // Update is called once per frame
    void Update () {
        t += Time.deltaTime;
        rbody.velocity = trajectory * 3;
        if (t > 2)
            GameObject.Destroy(this.gameObject);
	}
}
