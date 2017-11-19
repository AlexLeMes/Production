using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour {

    Bullet _bullet;

    public bool flamethrower;

    public float powerattacktimer = 0;

    public GameObject plasmaInUse;
    public GameObject fireInUse;

    public bool ischarging;
    public bool flamethrowerpicked;

    public int gas;
    public Slider gasBar;
    public GameObject gasBarObj;

    public GameObject plasma;
    public GameObject plasmaSpecial;

    public float powerattack;
    public float maxPowerattack;
    public Slider powerAttackBar;
    public GameObject powerAttackBarObj;
    float powerAttackCanUseValue;
    public float powerAttackChargeRate;

    public GameObject flameBullet;

    GameObject plasmashot;
    GameObject flameShot;

    public Vector3 weaponpos;
    public ParticleSystem flame;

    Rigidbody plasmarb;
    Rigidbody flameBulletRB;

    public float force;
    public float flameForce;
    
    public bool plasmaWeaponActive;

    public ParticleSystem chargingEffect;

    //gunLookat _gunLookat;
    bool canUseFlamethrower;

    public Text ammoText;
    public Text currentWeapon;
    bool showAmmo = false;

    // Use this for initialization
    void Start()
    {
        ischarging = false;
        plasmaWeaponActive = true;
        flamethrower = false;

        showAmmo = false;

        plasmaInUse.SetActive(true);
        powerAttackBarObj.SetActive(true);
        fireInUse.SetActive(false);
        gasBarObj.SetActive(false);

        currentWeapon.text = "Press '2' for Flamethrower";

        gasBar.value = gas;

        powerAttackBar.value = 0;

        powerAttackCanUseValue = powerAttackBar.maxValue;

        //flamethrowerpicked = false;

        //_gunLookat = this.gameObject.GetComponent<gunLookat>();
        //canUseFlamethrower = _gunLookat.canShoot;
        //  MAKE THIS BOOL WORK ?
    }


    void Update()
    {

        if (gas <= 0)
        {
            canUseFlamethrower = false;
        }
        else if (gas > 0)
        {
            canUseFlamethrower = true;
        }

        /*
        if (Input.GetMouseButton(1)) //starts the timer for charging the plasma weapon
        {
            ischarging = true;
        }
        */


        if (Input.GetMouseButton(1) && plasmaWeaponActive) //starts the timer for charging the plasma weapon
        {
            powerattacktimer += Time.deltaTime * powerAttackChargeRate;
            ischarging = true;
        }
        if (Input.GetMouseButtonUp(1) && powerattacktimer > powerAttackCanUseValue && ischarging && plasmaWeaponActive)
        {
            shootPowerAttack();
            powerattacktimer = 0;
        }
        if (Input.GetMouseButtonUp(1) && powerattacktimer < powerAttackCanUseValue && plasmaWeaponActive)
        {
            powerattacktimer = 0;
            ischarging = false;
        }
        if (Input.GetMouseButtonDown(0) /*&& powerattacktimer < 2*/ && plasmaWeaponActive)
        {
            shootPlasmaGun();
        }

        if (ischarging)
        {
            chargingEffect.Play();
        }
        else if (!ischarging)
        {
            chargingEffect.Stop();
        }

        powerAttackBar.value = powerattacktimer;

        //choose weapon

        //PLASMA GUN ACTIVE
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            flamethrower = false;
            plasmaWeaponActive = true;
            showAmmo = false;

            currentWeapon.text = "Press '2' for Flamethrower";

            fireInUse.SetActive(false);
            gasBarObj.SetActive(false);

            plasmaInUse.SetActive(true);
            powerAttackBarObj.SetActive(true);
        }

        //FLAME THROWER ACTIVE
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            plasmaWeaponActive = false;
            flamethrower = true;
            showAmmo = true;

            gasBar.value = gas / 10;

            currentWeapon.text = "Press '1' for Plasmagun";

            plasmaInUse.SetActive(false);
            powerAttackBarObj.SetActive(false);

            fireInUse.SetActive(true);
            gasBarObj.SetActive(true);
        }

        if (Input.GetMouseButton(0) && flamethrower && canUseFlamethrower)
        {
            flame.Play();
            shootFlameThrower();
            gas--;
            
        }
        else
        {
            flame.Stop();
        }

        gasBar.value = gas;
        
    }
    public void shootPlasmaGun()
    {
        plasmashot = Instantiate(plasma, transform.position, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.forward * force);

    }
    public void shootPowerAttack()
    {
        plasmashot = Instantiate(plasmaSpecial, transform.position, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.forward * force);
    }

    public void shootFlameThrower()
    {
        flameShot = Instantiate(flameBullet, transform.position, Quaternion.identity);
        flameBulletRB = flameShot.GetComponent<Rigidbody>();
        flameBulletRB.AddForce(transform.forward * flameForce);
    }
}

