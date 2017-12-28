using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    float maxhp = 100;
    public float curHp;
    public int Damage;
    Animator swordAnim;
    EnemyStates state;
    RaycastHit hit;
    bool isAttack; //атакуешь ли
    public Text nameEn;
    public Text hpEnemy;
    public EnemyStates EnST;
    CharacterController controller;



    // Use this for initialization
    void Start () {
        isAttack = false;
        curHp = maxhp;
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        swordAnim = GameObject.FindWithTag("Weapon").GetComponent<Animator>();
        nameEn.enabled = false;
        hpEnemy.enabled = false;
        
    }
	
	// Update is called once per frame
	void Update () {

        

        if (controller.velocity != Vector3.zero)
        {
            swordAnim.SetBool("idle", false);
            swordAnim.SetBool("walk", true);
        }
        else
        {
            swordAnim.SetBool("idle", true);
            swordAnim.SetBool("walk", false);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.green);
        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.collider.gameObject.tag == ("Enemy")) //&& controller.velocity == Vector3.zero)
            {
                //swordAnim.SetBool("attack", true);
                swordAnim.SetBool("walk", false);

                if (!isAttack)
                {
                    StartCoroutine(GiveAt());
                }
             
            }
        }
        if (Physics.Raycast(ray, out hit, 10))
        {

            if (hit.collider.gameObject.tag == ("Enemy"))
            {
                EnST = hit.collider.GetComponent<EnemyStates>();
                nameEn.enabled = true;
                hpEnemy.enabled = true;
                nameEn.text = "Name " + hit.collider.gameObject.name;
                hpEnemy.text = "HP " + EnST.curEnemyLife;
            }
            else
            {
                nameEn.enabled = false;
                hpEnemy.enabled = false;
            }
        }

    }

      IEnumerator  GiveAt()
    {
        isAttack = true;
        swordAnim.SetBool("idle", false);
        swordAnim.SetBool("attack", true);
        state = hit.collider.gameObject.GetComponent<EnemyStates>();    
        yield return new WaitForSeconds(0.5f/1.2f);
        swordAnim.SetBool("attack", false);
        swordAnim.SetBool("idle", true);
        state.GetDamage(UnityEngine.Random.Range(Damage, Damage + 3));
        yield return new WaitForSeconds(0.8f);
        isAttack = false;

    }

}
