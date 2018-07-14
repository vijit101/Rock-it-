using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketactor : MonoBehaviour {
    [SerializeField] float spd = 15;  
    [SerializeField] float dirsenstivity = 5;
    [SerializeField] float react = .03f;
    [SerializeField] float maxspeed = 10;
    Rigidbody myrb;
    public GameObject gmo;
    public GameObject gmo1;
    public Material blue;
   

	// Use this for initialization
	void Start () {
        myrb = GetComponent<Rigidbody>();
    
	}
    private void FixedUpdate()
    {
        thrust();
        dir();
        correction();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Utils.reloadcurrentscene();
        }
    }
    // Update is called once per frame
    void Update () {
      
	}
    //rocket control section 

        //add a transport script create a gmo with tag as teleporter and when collide trnslate rocket to teleport 
    private void thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myrb.AddRelativeForce(new Vector3(0, 1, 0) * spd, ForceMode.Force);
        }

    }
    private void dir()
    {
        if (Input.GetKey(KeyCode.D))
        {
            myrb.AddTorque(new Vector3(0, 0, -1)*dirsenstivity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myrb.AddTorque(new Vector3(0, 0, 1) * dirsenstivity);
        }
    }
    private void correction()
    {
        Vector3 vel = myrb.velocity;
        Vector3 projection = Vector3.Project(vel,transform.up);
        myrb.AddForce(-react * (vel - projection), ForceMode.Impulse);

    }
    private void speedcontrol()
    {
        Vector3 vel = myrb.velocity;
        if (vel.sqrMagnitude > maxspeed*maxspeed)
        {
            float presentvalue = vel.magnitude;
            myrb.AddForce(vel.normalized * (maxspeed - presentvalue),ForceMode.Impulse);
        }
    }
    //collision mechanics 

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Utils.reloadcurrentscene();
        }
        if (col.gameObject.tag == "Endpad")
        {
            Utils.loadnextscene();
        }
        if (col.gameObject.tag == "Button")
        {
            gmo.transform.position = gmo.transform.position + new Vector3(0, 2, 0);
        }
    }
 
}



