using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlayer : MonoBehaviour {

    public Transform rotTarget;
    public float speedRot;

	void Start () {
		
	}

    private void FixedUpdate()
    {
        Vector3 dir = rotTarget.position - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), speedRot*Time.deltaTime );
	}
}
