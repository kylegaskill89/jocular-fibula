using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
			
	// Radius around ship that can collide with objects
	float shipBoundary = .42f;
	
	
	// Use this for initialization
	void Start ()
    {
				
		
	}
	
	// Update is called once per frame
	void Update ()
    {


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
				

	}
}
