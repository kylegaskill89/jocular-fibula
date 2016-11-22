using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public GameObject targetObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {		
		Stats stats = targetObject.GetComponent<Stats>();
		Image fillAmt = GetComponent<Image>();

		fillAmt.fillAmount = (stats.currentHealth / stats.maxHealth);
	}
}
