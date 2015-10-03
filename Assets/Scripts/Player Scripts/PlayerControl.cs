using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	
	public GameObject PlayerBullet;
	
	// Radius around ship that can collide with objects
	float shipBoundary = .42f;
	
	
	public float cooldownTime = 10f;
	
	public float cooldownTimeTwo = 10f; 
	
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GameObject BulletOneSpawn = GameObject.Find ("BulletOneSpawn");
		GameObject BulletTwoSpawn = GameObject.Find ("BulletTwoSpawn");
		
		// Calls the Stats script
		
		Stats stats = GetComponent<Stats>();
		
		
		// This is where the horizontal movement is taken care of
		
		Input.GetAxis ("Horizontal");
		
		transform.Translate( new Vector3(Input.GetAxis ("Horizontal") * stats.maxSpeed * Time.deltaTime, 0, 0));
		
		
		// This part of the code handles screen boundaries
		
		Vector3 pos = transform.position;
		
		
		// Get the size of the camera so that the boundary can be set
		
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float orthoSize = Camera.main.orthographicSize * screenRatio;
		
		
		// Asks the application if the ship is leaving the camera view
		
		if (pos.x + shipBoundary > orthoSize) {
			pos.x = orthoSize - shipBoundary;
		}
		if (pos.x - shipBoundary < -orthoSize) {
			pos.x = -orthoSize + shipBoundary;
		}
		
		
		// If the ship is leaving the camera, then this puts it back at the edge
		
		transform.position = pos;
		
		
		// Timer increases between attacks
		
		cooldownTime += Time.deltaTime;
		cooldownTimeTwo += Time.deltaTime;

		
		// If the time since the last shot is higher than the attack speed and the player is pressing the button to shoot, then the timer is reset and the shot is fired
		
		if (cooldownTime >= stats.attackSpeed && Input.GetAxis ("Fire1") != 0) {
			Instantiate (PlayerBullet, BulletOneSpawn.transform.position, transform.rotation);
			cooldownTime = 0;
		}
		
		if (cooldownTimeTwo >= stats.attackSpeed && Input.GetAxis("Fire1") != 0) {
			Instantiate (PlayerBullet, BulletTwoSpawn.transform.position, transform.rotation);
			cooldownTimeTwo = 0;
		}
	}
}
