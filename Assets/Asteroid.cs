using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    Rigidbody rigidbody;
    public GameObject shards;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Mars" || col.gameObject.tag == "Bullet")
        {
            GameObject s = Instantiate(shards) as GameObject;
            s.transform.position = this.transform.position;// + this.transform.position.normalized * 0.1f;
            s.transform.rotation = this.transform.rotation;
            s.transform.localScale = this.transform.localScale;


            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = this.transform.position;// + this.transform.position.normalized * 0.1f;
            e.transform.rotation = this.transform.rotation;
            e.transform.localScale = this.transform.localScale * .01f;

            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update ()
    {
        rigidbody.velocity = -transform.position.normalized;
	}
}
