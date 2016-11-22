using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
		Stats stats = GetComponent<Stats>();

		transform.Translate( new Vector3((stats.currentSpeed) * Time.deltaTime, 0 , 0));

		// Kills enemies that go off the screen at a y of -6
		
		Vector3 pos = transform.position;
		
		if (pos.y < -6)
        {
			Destroy (this.gameObject);
		}
	}
}
