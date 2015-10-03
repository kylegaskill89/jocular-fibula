using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Grabs EnemyStats script

		Stats stats = GetComponent<Stats>();
		//BulletStats stats = GetComponent<BulletStats>();


		// Debug controls

		if (Input.GetKeyDown(KeyCode.Delete)) {
			stats.currentHealth = -1;
			Debug.Log ("Enemy Destroyed!");
		}

		if (stats.currentHealth <= 0) {
			Destroy (this.gameObject);
		}


	}
	//This will handle attacking the player

	}

