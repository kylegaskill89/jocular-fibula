using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour
{

    public string bulletType = "StandardBullet";

    public GameObject StdBul;
    public GameObject LasBul;

    public float cooldownTime = 10f;
    public float cooldownTimeTwo = 10f;

    public Transform playerShipFront;
    public Transform bulletHolder;


    // Update is called once per frame
    void Update ()
    {

        // Timer increases between attacks

        cooldownTime += Time.deltaTime;
        cooldownTimeTwo += Time.deltaTime;

        if (bulletType == "StandardBullet")
        {
            StandardBullet();
        }

        if (bulletType == "Laser")
        {
            LaserShot();
        }

    }

    void StandardBullet()
    {

        GameObject BulletOneSpawn = GameObject.Find("BulletOneSpawn");
        GameObject BulletTwoSpawn = GameObject.Find("BulletTwoSpawn");

        Stats stats = GetComponent<Stats>();



        // If the time since the last shot is higher than the attack speed and the player is pressing the button to shoot, then the timer is reset and the shot is fired

        if (cooldownTime >= stats.attackSpeed && Input.GetAxis("Fire1") != 0)
        {
            GameObject cloneLeft = Instantiate(StdBul, BulletOneSpawn.transform.position, transform.rotation);
            cloneLeft.transform.parent = bulletHolder;
            cooldownTime = 0;
        }

        if (cooldownTimeTwo >= stats.attackSpeed && Input.GetAxis("Fire2") != 0)
        {
            GameObject cloneRight =  Instantiate(StdBul, BulletTwoSpawn.transform.position, transform.rotation);
            cloneRight.transform.parent = bulletHolder;
            cooldownTimeTwo = 0;
        }

    }

    void LaserShot()
    {
        GameObject BulletFrontSpawn = GameObject.Find("BulletFrontSpawn");

        if (Input.GetAxis("Fire1") != 0)
        {                     
            GameObject cloneLasBul = Instantiate(LasBul, BulletFrontSpawn.transform.position, transform.rotation);
            cloneLasBul.transform.parent = playerShipFront;                    
        }
    } 

}