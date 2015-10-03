using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {


	// Update is called once per frame
	void Update () {

		// Calls the BulletStats script
		
		BulletStats Stats = GetComponent<BulletStats>();


		transform.Translate( new Vector3(0, Stats.maxSpeed * Time.deltaTime, 0));


		// This part of the code handles screen boundaries
		
		Vector3 pos = transform.position;
		
		if (pos.y > Camera.main.orthographicSize) {
			Destroy(this.gameObject);
		}

		//if (stats.currentBulletHP <= 0) {
		//	Destroy(this.gameObject);
		//}
	}
	void OnCollisionEnter2D (Collision2D bul) {
		if (bul.collider.gameObject.tag == "Enemy") {
			Destroy (this.gameObject);
		}
	}
}