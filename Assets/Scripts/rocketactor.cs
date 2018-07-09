using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketactor : MonoBehaviour {
    [SerializeField] float speed = 1;
    Rigidbody myrb;

	// Use this for initialization
	void Start () {
        myrb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        thrust();
	}
    private void thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myrb.AddRelativeForce(new Vector3(0,1,0)* speed,ForceMode.Force);
            Debug.Log("inside thrust");
        }
    }

}
