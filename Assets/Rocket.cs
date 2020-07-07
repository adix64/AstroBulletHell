using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {
    GameObject r1, r2, r3, r4, r5;
    public int HP = 100;
    // Use this for initialization
    MyUIscript uiscript;

    void Start ()
    {
        r1 = transform.Find("r1").gameObject;
        r1.active = true;
        r2 = transform.Find("r2").gameObject;
        r2.active = false;
        r3 = transform.Find("r3").gameObject;
        r3.active = false;
        r4 = transform.Find("r4").gameObject;
        r4.active = false;
        r5 = transform.Find("r5").gameObject;
        r5.active = false;
        uiscript = GameObject.FindWithTag("UItag").GetComponent<MyUIscript>();
    }

    public void Reset()
    {
        r1.active = true;
        HP = 100;
    }
    void OnCollisionEnter(Collision col)
    {
        if (uiscript.onPause)
            return;
        //Debug.Log("HP:" + HP);
        if (col.gameObject.tag == "Asteroid")
        {
            HP -= (int)(col.gameObject.transform.localScale.x * 20f);
            Debug.Log("HP:" + HP);
            r1.active = r2.active = r3.active = r4.active = r5.active = false;
            if (HP > 80)
                r1.active = true;
            else if (HP > 60)
                r2.active = true;
            else if (HP > 40)
                r3.active = true;
            else if (HP > 20)
                r4.active = true;
            else if (HP > 0)
                r5.active = true;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
