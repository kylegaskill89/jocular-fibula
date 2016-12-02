using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour
{

    public string bulletType = "StandardBullet";

    public GameObject StdBul;
    public GameObject LasBul;

    public float cooldownTime = 10f;
    public float cooldownTimeTwo = 10f;



	// Update is called once per frame
	void Update ()
    {

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

        // Timer increases between attacks

        cooldownTime += Time.deltaTime;
        cooldownTimeTwo += Time.deltaTime;


        // If the time since the last shot is higher than the attack speed and the player is pressing the button to shoot, then the timer is reset and the shot is fired

        if (cooldownTime >= stats.attackSpeed && Input.GetAxis("Fire1") != 0)
        {
            Instantiate(StdBul, BulletOneSpawn.transform.position, transform.rotation);
            cooldownTime = 0;
        }

        if (cooldownTimeTwo >= stats.attackSpeed && Input.GetAxis("Fire2") != 0)
        {
            Instantiate(StdBul, BulletTwoSpawn.transform.position, transform.rotation);
            cooldownTimeTwo = 0;
        }

    }

    void LaserShot()
    {
        GameObject BulletFrontSpawn = GameObject.Find("BulletFrontSpawn");

        if (Input.GetAxis("Fire1") != 0)
        {            
            Instantiate(LasBul, BulletFrontSpawn.transform.position, transform.rotation);            
        }
    } 

}
