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
    Vector3 startPos;
    GiveCollor scripCol;
    public GameObject alphObj;
    AudioSource audio;
    public AudioClip[] step;


    void Start () {
        scripCol = alphObj.GetComponent<GiveCollor>();
        alphObj.SetActive(false);
        controller = GetComponent<CharacterController>();
        startPos = transform.position;
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.loop = false;
    }

    private void Update()
    {
        if (transform.position.y <= -0.5f)
        {
            StartCoroutine(darkPan());
            audio.clip = step[1];
        }
        else
        {
            audio.clip = step[0];
        }

        if (controller.velocity != Vector3.zero)
        {
            if(!audio.isPlaying)
            {
                RaycastHit hit1;
                if(Physics.Raycast(transform.position + Vector3.up, -Vector3.up, out hit1, 1 ))
                {
                    if (hit1.collider.tag == "ground")
                    {
                        audio.clip = step[0];
                    }
                    audio.Play();
                }

            }
        }

        if (controller.isGrounded)
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

    IEnumerator darkPan()
    {
        alphObj.SetActive(true);
        scripCol.checkColor = true;
        yield return new WaitForSeconds(1);
        transform.position = startPos;
        scripCol.checkColor = false;
        yield return new WaitForSeconds(1.2f);
        alphObj.SetActive(false);
    }



}
