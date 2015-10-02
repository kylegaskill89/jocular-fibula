using UnityEngine;
using System.Collections;

public class EnemyTest : MonoBehaviour {

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		// Calls the Stats script
		
		Stats stats = GetComponent<Stats>();

		transform.Translate( new Vector3(0, -stats.maxSpeed * Time.deltaTime, 0));


	
	}
}
