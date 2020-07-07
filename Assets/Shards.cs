using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shards : MonoBehaviour {

    float t;
    public Rigidbody[] shards;
    [SerializeField]
    public AudioClip boom1, boom2, boom3;
    // Use this for initialization
    void Start () {
        shards = new Rigidbody[this.transform.childCount];
        for (int i = 0; i < this.transform.childCount; i++)
        {
            shards[i] = transform.GetChild(i).gameObject.GetComponent<Rigidbody>();
        }
        t = 0;
        AudioClip chosen;
        float r = Random.Range(0.0f, 1.0f);
        if (r < 0.33333)
            chosen = boom1;
        else if (r < 0.66666)
            chosen = boom2;
        else chosen = boom3;

        AudioSource asrc = GetComponent<AudioSource>();
        asrc.clip = chosen;
        asrc.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
        if (t > 1.5f)
            GameObject.Destroy(this.gameObject);

        if (t < 0.1f)
            for (int i = 0; i < this.transform.childCount; i++)
            {
                shards[i].AddForce(-shards[i].position.normalized * 0.1f * this.transform.localScale.x);
            }
    }

}
