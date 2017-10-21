using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	
	public bool isBoss;
	
	// Health
	public float maxHealth = 100f;
	public float currentHealth = 100f;
	
	// Speed
	public float maxSpeed = 25f;
	public float currentSpeed = 25f;
	
	// Attack
	public float attackDamage = 1f;
	
	// Attack Speed
	public float attackSpeed = 0.1f;

    // Special Attack
    public float specialChargeNeeded = 100f;
    public float currentSpecialCharge = 0f;

    // Charge Effect
    public float chargeEffect;

    // Powerup Time
    public float powerupTime = 5f;


  /*
    
    public void DrainSpecial()
    {
        while (currentSpecialCharge > 0)
        {
            currentSpecialCharge -= Time.deltaTime;
        }
    }

	*/

}
