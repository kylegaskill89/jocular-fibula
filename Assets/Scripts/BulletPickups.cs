using UnityEngine;
using System.Collections;

public class BulletPickups : MonoBehaviour {

    public string pickupType;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(0, (-1f * Time.deltaTime), 0));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {            
            ShotManager shotManager = other.GetComponent<ShotManager>();
            shotManager.bulletType = pickupType;
            Destroy(gameObject);
        }
    }

}
