using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour {
    public Transform Target;
    public Vector3 Offset;

    public Rigidbody player;
    Animator anim;
    Transform chest;
    Transform arm;
    public Camera camera;
    float fireTimeout = 0;
    public GameObject laserBullet;
    GameObject jet;
    // Use this for initialization
    void Start ()
    {
        jet = transform.Find("JET").gameObject;
        anim = GetComponent<Animator>();
        chest = anim.GetBoneTransform(HumanBodyBones.Spine);
        arm = anim.GetBoneTransform(HumanBodyBones.LeftHand);
        Debug.Log(chest);
        player = GetComponent<Rigidbody>();
        player.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }
   
    // Update is called once per frame
    void Update ()
    {
		
	}

    void Fire()
    {
        if (fireTimeout > 0.06f && Input.GetMouseButton(0))
        {
            fireTimeout = 0f;
            GameObject go = GameObject.Instantiate(laserBullet);
           
            LaserBullet lb = go.GetComponent<LaserBullet>();
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(player);
                Vector3 hitpoint = new Vector3(hit.point.x, hit.point.y, 0);
                Vector3 pos2d = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                lb.trajectory = (hitpoint - pos2d).normalized;

                go.transform.position = arm.position + lb.trajectory * 0.1f;

                var axis = Vector3.Cross(Vector3.up, lb.trajectory);
                var dott = Vector3.Dot(Vector3.up, lb.trajectory);

                var rotation = Quaternion.AxisAngle(axis.normalized, Mathf.Acos(dott));
                //rotation *= _facing;
                lb.transform.rotation = rotation;
            }
            anim.SetTrigger("shoot");
        }else anim.SetTrigger("stopshooting");
    }
    void FixedUpdate()
    {
        fireTimeout += Time.fixedDeltaTime;

        Vector3 marsDir = (Vector3.zero -this.transform.position).normalized;
        float gravityFact = 1f / Mathf.Pow(Vector3.Distance(Vector3.zero, transform.position), .25f);
        player.AddForce(200 * marsDir * gravityFact);
        Fire();
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(player);
                Vector3 hitpoint = new Vector3(hit.point.x, hit.point.y, 0);
                Vector3 pos2d = new Vector3(this.transform.position.x, this.transform.position.y, 0);
                player.AddForce(400 * (hitpoint - pos2d).normalized * Mathf.Min(1, 30 * Vector3.Distance(hitpoint, pos2d)));
            }
            jet.active = true;
        }
        else
            jet.active = false;

        float dot = Vector3.Dot(-marsDir, new Vector3(0, 1, 0));
        float angle =- Mathf.Acos(dot) * 180f / Mathf.PI * Mathf.Sign(transform.position.x);
        //Debug.Log("Acos:"+ angle + "Dot:" + dot);
        Quaternion q = Quaternion.Euler(0, 0, angle);
        q = Quaternion.Slerp(q, chest.rotation, 0.85f);
        

        transform.rotation = Quaternion.EulerAngles(0,0,Quaternion.ToEulerAngles(q).z);
    }
    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            chest.LookAt(hit.point);
            // Do something with the object that was hit by the raycast.
        }
        //chest.LookAt(Target.position);
        //chest.rotation = chest.rotation * Quaternion.Euler(Offset);
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
}
