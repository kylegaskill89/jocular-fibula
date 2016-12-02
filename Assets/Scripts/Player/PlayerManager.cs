using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    public Text gameOverText;


	// Use this for initialization
	void Start ()
    {
        
	}

	
	// Update is called once per frame
	void Update ()
    {
        Stats stats = GetComponent<Stats>();
        if (stats.currentHealth <= 0)
        {
            StartCoroutine(Die());
        }

        if (stats.currentHealth >= stats.maxHealth)
        {
            stats.currentHealth = stats.maxHealth;
        }
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


    IEnumerator Die()
    {
        Time.timeScale = 0;
        gameOverText.enabled = true;
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Shooter");
        Time.timeScale = 1;
        yield return null;
    }
}
