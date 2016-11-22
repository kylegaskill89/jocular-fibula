using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
	}

	
	// Update is called once per frame
	void Update ()
    {
        Stats stats = GetComponent<Stats>();
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Stats stats = GetComponent<Stats>();
            stats.currentHealth -= 25f;            
            EnemyController enemyController = other.GetComponent<EnemyController>();
            enemyController.DealDamage(100f);            
        }
    }


    public void Heal(float healAmt)
    {
        Stats stats = GetComponent<Stats>();
        stats.currentHealth += healAmt;
    }

}
