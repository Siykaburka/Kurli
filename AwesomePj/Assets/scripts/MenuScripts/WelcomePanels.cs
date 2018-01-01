using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomePanels : MonoBehaviour {

    public Text welcText;


    void Start () {
        welcText.text = "Добро пожаловать, " + PlayerPrefs.GetString("Name") + "!";
	}
	
    public void closedPanel()
    {
        Destroy(gameObject);
    }

}
