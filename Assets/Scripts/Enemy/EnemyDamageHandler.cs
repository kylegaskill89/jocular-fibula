using UnityEngine;
using System.Collections;

public class EnemyDamageHandler : MonoBehaviour {

	public float health = 1f;

	void OnCollisionEnter2D() {

		GameObject bullet = GameObject.Find ("PlayerBullet");
		BulletStats bulletDamage = bullet.GetComponent<BulletStats>();
		health -= bulletDamage.bulletDamage;

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
