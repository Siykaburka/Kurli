using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float distanceFromPlayer;
    Animator anim;
    public GameObject player;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if(distanceFromPlayer <= 7.5f && distanceFromPlayer > 3.2f)
        {             
                anim.SetBool("walk", true);
                anim.SetBool("idle", false);
                anim.SetBool("attack", false);
                transform.LookAt(player.transform.position);
                if (distanceFromPlayer > 3.2f)
                {
                    agent.SetDestination(player.transform.position);
                }
                      
        }

        if (distanceFromPlayer <= 3.2f)
        {
            StartCoroutine(attack());

        }

        if (distanceFromPlayer >= 7.5f)
        {
            anim.SetBool("idle", true);
            anim.SetBool("walk", false);
        }

    }
    IEnumerator attack()
    {
        anim.SetBool("walk", false);
        anim.SetBool("attack", true);
        transform.LookAt(player.transform.position);
        yield return new WaitForSeconds(0.5f);
    }
}
