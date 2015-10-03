using UnityEngine;
using System.Collections;

public class PlayerDamageHandler : MonoBehaviour {

	public float health = 1f;

	void OnTriggerEnter2D() {
		health--;
	}
	
	void Update() {
		if (health <= 0) {
			Die();
		}
	}
	
	void Die() {
		Destroy (gameObject);
	}
}
