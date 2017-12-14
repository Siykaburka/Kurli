using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teachScene : MonoBehaviour {

    public GameObject teachScroll;
    public GameObject teachMove;
    public GameObject joystic;
    bool destroy = false;

    void Start () {
        joystic.SetActive(false);
        teachScroll.SetActive(true);
        teachMove.SetActive(false);
    }
	
	void Update () {

        if (destroy == true)
        {
            Destroy(gameObject, 1);
        }
        
    }

    public void tochTeachScroll()
    {
        Destroy(teachScroll);
        StartCoroutine(on());
    }

    public void tochTeachMove()
    {
        Destroy(teachMove);
        destroy = true;
    }


    IEnumerator on()
    {
        yield return new WaitForSeconds(3);
        teachMove.SetActive(true);
        joystic.SetActive(true);
    }
}
