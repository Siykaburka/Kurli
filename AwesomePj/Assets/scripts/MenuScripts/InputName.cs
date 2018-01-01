using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

    public InputField Infield;
    GameObject PanelWithNameInput;
    public Text error;
    GameObject welcomePanel;

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
        welcomePanel = GameObject.Find("WelcomePanel");
        PanelWithNameInput = GameObject.Find("InputNamePanel");
        welcomePanel.SetActive(false);
        

        if (!PlayerPrefs.HasKey("Name") || PlayerPrefs.GetString("Name").Length <=2)
        {
            PanelWithNameInput.SetActive(true);
        }
        else
        {
            PanelWithNameInput.SetActive(false);
            welcomePanel.SetActive(true);
            PlayerPrefs.Save();
        }
    }
	
	public void InputN()
    {
        if (Infield.text.Length > 2)
        {
            PlayerPrefs.SetString("Name", Infield.text);
            PanelWithNameInput.SetActive(false);
            PlayerPrefs.Save();
            welcomePanel.SetActive(true);
        }
        else
        {
            error.enabled = true; 
        }
    }
}
