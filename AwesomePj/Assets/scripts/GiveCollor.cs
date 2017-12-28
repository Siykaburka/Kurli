using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveCollor : MonoBehaviour {


    public bool checkColor;
    Image AlphaImage;


	// Use this for initialization
	void Start () {

        checkColor = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (checkColor == true)
        {
            AlphaImage = gameObject.GetComponent<Image>();
            if (AlphaImage.color.a <= 1f)
            {
                AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.b, AlphaImage.color.g, AlphaImage.color.a + 1.8f * Time.deltaTime);
            }
        }
        if (checkColor == false)
        {
            AlphaImage = gameObject.GetComponent<Image>();
            if (AlphaImage.color.a >= 0.1f)
            {
                AlphaImage.color = new Color(AlphaImage.color.r, AlphaImage.color.b, AlphaImage.color.g, AlphaImage.color.a - 0.2f * Time.deltaTime);
            }
        }


    }
}
