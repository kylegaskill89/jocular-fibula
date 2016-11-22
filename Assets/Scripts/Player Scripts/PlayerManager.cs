using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    private Text healthText;

	// Use this for initialization
	void Start ()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
	}

	
	// Update is called once per frame
	void Update ()
    {
        Stats stats = GetComponent<Stats>();

        // Display health count
        healthText.text = "Health: " + ((stats.currentHealth / stats.maxHealth) * 100).ToString("0");
	}
}
