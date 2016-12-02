using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugManager : MonoBehaviour 
{

    public bool debugMode = false;

    public Text DebugModeText;

    public GameObject stdEnemy;

    // Use this for initialization
    void Start () 
	{
	    
	}
	
	// Update is called once per frame
	void Update () 
	{
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
	}

}
