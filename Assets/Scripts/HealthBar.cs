using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject PlayerShip = GameObject.Find ("PlayerShip");
		Stats stats = PlayerShip.GetComponent<Stats>();
		Image fillAmt = GetComponent<Image>();

		fillAmt.fillAmount = (stats.currentHealth / stats.maxHealth);
	}
}
