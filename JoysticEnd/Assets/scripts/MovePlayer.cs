using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float speedMove;
    public float GravityForce;
    CharacterController controller;
    Vector3 direction;
    float x;
    float y;


	void Start () {

        controller = GetComponent<CharacterController>();

	}

    private void Update()
    {
        if(controller.isGrounded)
        {
            direction = new Vector3(x, 0, y);
            direction = transform.TransformDirection(direction) * speedMove;
        }

        direction.y -= GravityForce * Time.deltaTime;

        controller.Move(direction * Time.deltaTime);
    }

    public void GetVector( Vector2 dir)
    {
        x = dir.x;
        y = dir.y;
    }



}
