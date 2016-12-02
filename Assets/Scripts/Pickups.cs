using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour 
{

    public float healFactor;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        transform.Translate(new Vector3(0, (-1f * Time.deltaTime), 0));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            playerManager.Heal(healFactor);
            Destroy(gameObject);
        }
    }

}
