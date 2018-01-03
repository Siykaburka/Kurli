using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

    public InputField Infield;
    GameObject PanelWithNameInput;
    public Text error;
    GameObject GlavPanel;

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
        GlavPanel = GameObject.Find("GlavMenu");
        PanelWithNameInput = GameObject.Find("InputNamePanel");
        GlavPanel.SetActive(false);
        

        if (!PlayerPrefs.HasKey("Name") || PlayerPrefs.GetString("Name").Length <=2)
        {
            PanelWithNameInput.SetActive(true);
        }
        else
        {
            PanelWithNameInput.SetActive(false);
            GlavPanel.SetActive(true);
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
            GlavPanel.SetActive(true);
        }
        else
        {
            error.enabled = true; 
        }
    }
}
