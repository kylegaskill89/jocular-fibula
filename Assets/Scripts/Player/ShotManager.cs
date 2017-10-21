using UnityEngine;
using System.Collections;

public class ShotManager : MonoBehaviour
{
    public bool canFireReg = true;

    public string bulletType = "StandardBullet";
    public string powerupType;
    public string specialAtk = "StandardSpecial";
    

    public GameObject StdBul;
    public GameObject LasBul;

    public GameObject SprdSht;
    public bool powerup = false;
    float powerupTimer;

    public GameObject StdSpecial;

    float cooldownTime = 10f;
    float cooldownTimeTwo = 10f;

    public Transform playerShipFront;
    public Transform bulletHolder;


    // Update is called once per frame
    void Update()
    {

        // Normal shot logic

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

        // Pickup shot logic

        if (powerupType == "SpreadShot" && powerup)
        {
            canFireReg = false;
            SpreadShot();
        }

        // Special shot logic

        if (specialAtk == "StandardSpecial")
        {
            StandardSpecial();
        }

    }

    void StandardBullet()
    {

        GameObject BulletOneSpawn = GameObject.Find("BulletOneSpawn");
        GameObject BulletTwoSpawn = GameObject.Find("BulletTwoSpawn");

        Stats stats = GetComponent<Stats>();



        // If the time since the last shot is higher than the attack speed and the player is pressing the button to shoot, then the timer is reset and the shot is fired

        if (canFireReg && cooldownTime >= stats.attackSpeed && Input.GetAxis("Fire1") != 0)
        {
            GameObject cloneLeft = Instantiate(StdBul, BulletOneSpawn.transform.position, transform.rotation);
            cloneLeft.transform.parent = bulletHolder;
            cooldownTime = 0;
        }

        if (canFireReg && cooldownTimeTwo >= stats.attackSpeed && Input.GetAxis("Fire2") != 0)
        {
            GameObject cloneRight = Instantiate(StdBul, BulletTwoSpawn.transform.position, transform.rotation);
            cloneRight.transform.parent = bulletHolder;
            cooldownTimeTwo = 0;
        }

    }

    void LaserShot()
    {
        GameObject BulletFrontSpawn = GameObject.Find("BulletFrontSpawn");

        if (canFireReg && Input.GetAxis("Fire1") != 0)
        {
            GameObject cloneLasBul = Instantiate(LasBul, BulletFrontSpawn.transform.position, transform.rotation);
            cloneLasBul.transform.parent = playerShipFront;
        }
    }

    void SpreadShot()
    {
        Stats stats = GetComponent<Stats>();
        powerupTimer += Time.deltaTime;

        if (cooldownTime >= stats.attackSpeed && powerupTimer <= stats.powerupTime && Input.GetAxis("Fire1") != 0)
        {
            GameObject cloneFront = Instantiate(StdBul, playerShipFront.transform.position, transform.rotation);
            cloneFront.transform.parent = bulletHolder;
            cooldownTimeTwo = 0;
            Debug.Log(powerupTimer);
        }

        if (powerupTimer > stats.powerupTime)
        {
            powerup = false;
            canFireReg = true;
            powerupTimer = 0;
        }
    }

    void StandardSpecial()
    {
        Stats stats = GetComponent<Stats>();

        if (stats.currentSpecialCharge >= stats.specialChargeNeeded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bankai");
            stats.currentSpecialCharge = 0;
        }
        else if(stats.currentSpecialCharge < stats.specialChargeNeeded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Your special meter is not charged");
        }

    }

}