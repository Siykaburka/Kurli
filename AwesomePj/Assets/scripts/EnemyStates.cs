using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour {

    public float EnemyLife;
    public float curEnemyLife;
    float damage;
    public GameObject ragDoll;
    AudioSource audio;
    public AudioClip[] mobsSounds;


    void Start () {

        curEnemyLife = EnemyLife;

        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(curEnemyLife <=0)
        {
            Dead();
        }

	}

    public void GetDamage(float dmg)
    {
        curEnemyLife -= dmg;
        audio.clip = mobsSounds[0];
        audio.Play();
    }

    void Dead()
    {
        GameObject rd = Instantiate(ragDoll, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(rd, 5);
    }

}
