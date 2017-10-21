using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugManager : MonoBehaviour 
{

    public bool debugMode = false;

    public Text DebugModeText;
    
    public GameObject stdEnemy;
    public GameObject player;

    // Use this for initialization
    void Start () 
	{
	    
	}
	
	// Update is called once per frame
	void Update () 
	{

        PlayerManager playerManager = player.GetComponent<PlayerManager>();


        if (debugMode)
        {
            DebugModeText.text = "Debug Mode: On";
        }
        else
        {
            DebugModeText.text = "Debug Mode: Off";
        }

        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            debugMode = !debugMode;
        }

        if (debugMode && (Input.GetKeyDown(KeyCode.Alpha1)))
        {
            Instantiate(stdEnemy, new Vector3(0, 2.5f, 0), transform.rotation);
        }

        if (debugMode && (Input.GetKeyDown(KeyCode.Alpha2)))
        {
            playerManager.godMode = !playerManager.godMode;
        }

        if (debugMode && (Input.GetKeyDown(KeyCode.Alpha3)))
        {
            ShotManager playerShotManager = GameObject.Find("PlayerShip").GetComponent<ShotManager>();
            playerShotManager.powerup = true;
        }
    }

}
