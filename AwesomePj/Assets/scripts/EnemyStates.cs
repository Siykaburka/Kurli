using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour {

    public float EnemyLife;
    public float curEnemyLife;
    float damage;
    public GameObject ragDoll;


	
	void Start () {

        curEnemyLife = EnemyLife;
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
    }

    void Dead()
    {
        GameObject rd = Instantiate(ragDoll, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(rd, 5);
    }

}
