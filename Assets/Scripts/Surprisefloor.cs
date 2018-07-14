using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprisefloor : MonoBehaviour {
    public Material blue;
    Renderer myrender;
    // Use this for initialization
    void Start()
    {
        myrender = GetComponent<Renderer>();
        myrender.enabled = true;
    }
    // Update is called once per frame
    private void OnCollisionEnter(Collision mycol)
    {
        if (mycol.gameObject.tag == "myrocket")
        {
            myrender.material = blue;
        }
    }
}
