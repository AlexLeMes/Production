using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wepaon : MonoBehaviour {

    public bool flamethrower;

    public float powerattacktimer = 0;
    public bool ischarging;
    public bool flamethrowerpicked;
    public GameObject ammopack;
    public GameObject gaspack;
    public int ammo;
    public int gas;
    public GameObject plasma;
    public GameObject plasmashot;
    public Vector3 weaponpos;
    public ParticleSystem flame;
    Rigidbody plasmarb;
    public float force;
    public float powerattack;
    public bool plasmadf;
    public ParticleSystem charging;

    gunLookat _gunLookat;
    bool canshoot;

    public Text ammoText;

    // Use this for initialization
    void Start ()
    {
        ischarging = false;
        plasmadf = true;
        flamethrower = false;
        flamethrowerpicked = false;

        _gunLookat = this.gameObject.GetComponent<gunLookat>();
        canshoot = _gunLookat.canShoot;
        //  MAKE THIS BOOL WORK
    }


    void Update() {

        if (ischarging == true)
        {
            charging.Play();

        }
        else
        {
            charging.Stop();
        }
        
        Destroy(plasmashot, 2);
        weaponpos = transform.position;

        ammoText.text = "Ammo: " + ammo.ToString();
        if(ammo <= 0)
        {
            canshoot = false;
        }
        else if(ammo > 0)
        {
            canshoot = true;
        }

        if (Input.GetMouseButton(1) && plasmadf == true && canshoot==true) //starts the timer for charging the plasma weapon
        {
            powerattacktimer += Time.deltaTime;
            ischarging = true;
        }
        if(Input.GetMouseButtonUp(1) && powerattacktimer > 2 && ischarging==true && plasmadf == true && canshoot == true) 
        {
            powerattackpl();
            ammo -= 3;
            powerattacktimer = 0;
        }
        if(Input.GetMouseButtonUp(1) && powerattacktimer < 2 && plasmadf == true && canshoot == true)
        {
            powerattacktimer = 0;
            ischarging = false;
        }
        if (Input.GetMouseButtonDown(0) && powerattacktimer < 2 && plasmadf == true && canshoot == true && canshoot == true)
        {
            plasmagun();
            ammo --;
        }
        if (flamethrowerpicked==true)
        {
            chooseweapon();

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            flamethrower = true;
            plasmadf = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            plasmadf = true;
            flamethrower = false;
        }
        if (Input.GetMouseButton(0) && flamethrower == true && canshoot == true)
        {
            flame.Play();
            gas--;
        }
        else
        {
            flame.Stop();
        }

    }
    public void plasmagun()
    {
        plasmashot = Instantiate(plasma, weaponpos, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.forward * force);

    }
    public void powerattackpl()
    {
        plasmashot = Instantiate(plasma, weaponpos, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.forward * force * powerattack);
        plasmashot.transform.localScale = new Vector3(5, 5, 5);

    }
    public void chooseweapon()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)&& flamethrowerpicked == true)
        {
            flamethrower = true;
            plasmadf = false;
        }
        else if( Input.GetKeyDown(KeyCode.Alpha2))
        {
            plasmadf = true;
            flamethrower = false;
        }
        

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<wepaon>()!=null)
        {
            flamethrowerpicked = true;
        }
    }
    

}
