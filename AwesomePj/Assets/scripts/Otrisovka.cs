using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otrisovka : MonoBehaviour {

    public GameObject player;
    float distance;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if(distance > 25)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
	}
}
