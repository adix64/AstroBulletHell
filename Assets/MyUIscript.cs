using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUIscript : MonoBehaviour {
    GameObject txt;
    GameObject victory, defeat;
    TMPro.TextMeshProUGUI tmp;
    Rocket rocket;
    float timeLeft = 60;
    public bool onPause = false;
    float notificationTime = 5.0f;
    // Use this for initialization
    void Start () {
        txt = transform.GetChild(0).gameObject;
        tmp = txt.GetComponent<TMPro.TextMeshProUGUI>();
        rocket = GameObject.Find("Rocket").GetComponent<Rocket>();
        victory = transform.GetChild(1).gameObject;
        defeat = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.5f);
        onPause = false;
        victory.active = defeat.active = false;
        timeLeft = 60;
        rocket.Reset();
    }

    void FixedUpdate () {
        if (onPause)
        {
            Time.timeScale = 0.1f;
            StartCoroutine(Reset());

            if ((int)rocket.HP > 0)
                victory.active = true;
            else
                defeat.active = true;
        }
        else
        {
            Time.timeScale = 1f;

            timeLeft -= Time.fixedDeltaTime;
            tmp.text = "Mothership " + (rocket.HP > 0 ? rocket.HP.ToString() : "X")+ "\n\tTime " + (int)timeLeft;

            if (timeLeft <= 0 || rocket.HP < 0)
            {
                notificationTime = 5.0f;
                onPause = true;
            }
        }
        
	}
}
