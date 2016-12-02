using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		// Calls the BulletStats script
		
		BulletStats bulletStats = GetComponent<BulletStats>();


		transform.Translate( new Vector3(0, bulletStats.maxSpeed * Time.deltaTime, 0));


		// This part of the code handles screen boundaries
		
		Vector3 pos = transform.position;
		
		if (pos.y > Camera.main.orthographicSize) {
			Destroy(this.gameObject);
		}

		//if (stats.currentBulletHP <= 0) {
		//	Destroy(this.gameObject);
		//}
	}
	void OnTriggerEnter2D (Collider2D enemy)
    {        
		if (enemy.gameObject.tag == "Enemy")
        {
            BulletStats bulletStats = GetComponent<BulletStats>();
            EnemyController enemyController = enemy.GetComponent<EnemyController>();
            enemyController.DealDamage(bulletStats.bulletDamage);
            Destroy(gameObject);
        }
	}
}