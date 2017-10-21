using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {

		// Grabs EnemyStats script

		Stats stats = GetComponent<Stats>();
		//BulletStats stats = GetComponent<BulletStats>();


		// Debug controls

		if (Input.GetKeyDown(KeyCode.Delete))
        {
			stats.currentHealth = -1;
			Debug.Log ("Enemy Destroyed!");
		}

		if (stats.currentHealth <= 0)
        {
            EnemyDeath();            
		}


	}


    public void DealDamage(float dmgAmt)
    {
        Stats stats = GetComponent<Stats>();
        stats.currentHealth -= dmgAmt;
    }

    public void EnemyDeath()
    {
        Stats enemyStats = GetComponent<Stats>();
        Stats playerStats = GameObject.Find("PlayerShip").GetComponent<Stats>();
        playerStats.currentSpecialCharge += enemyStats.chargeEffect;
        Destroy(this.gameObject);        
    }

}


