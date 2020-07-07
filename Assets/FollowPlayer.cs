using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        var tp = new Vector3(transform.position.x, transform.position.y, 0);
        var ptp = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        float dist = Vector3.Distance(tp, ptp);
        if (dist > 0f)
        {
            transform.position  = transform.position + (ptp - tp).normalized * Time.deltaTime * Mathf.Min(1.0f, dist);
        }
	}
}
