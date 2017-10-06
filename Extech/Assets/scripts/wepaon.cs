using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Rigidbody plasmarb;
    public float force;
    public float powerattack;
    public bool plasmadf;

    // Use this for initialization
    void Start () {
        ischarging = false;
        plasmadf = true;
        flamethrower = false;
        flamethrowerpicked = false; 


    }

    // Update is called once per frame
    void Update() {
        
        Destroy(plasmashot, 2);
        weaponpos = transform.position;
        if (Input.GetMouseButton(0) && plasmadf == true) //starts the timer for charging the plasma weapon
        {
            powerattacktimer += Time.deltaTime;
            ischarging = true;
        }
        if(Input.GetMouseButtonUp(0) && powerattacktimer > 2 && ischarging==true && plasmadf == true) 
        {
            powerattackpl();
            ammo -= 3;
            powerattacktimer = 0;
        }
        if(Input.GetMouseButtonUp(0) && powerattacktimer < 2 && plasmadf == true)
        {
            powerattacktimer = 0;
            ischarging = false;
        }
        if (Input.GetMouseButtonDown(0) && powerattacktimer < 2 && plasmadf == true)
        {
            plasmagun();
            ammo --;
        }
        if (flamethrowerpicked==true)
        {
            chooseweapon();

        }
        if(Input.GetMouseButton(0) && flamethrower == true)
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
        plasmarb.AddForce(transform.right * force);

    }
    public void powerattackpl()
    {
        plasmashot = Instantiate(plasma, weaponpos, Quaternion.identity);
        plasmarb = plasmashot.GetComponent<Rigidbody>();
        plasmarb.AddForce(transform.right * force * powerattack);
        plasmashot.transform.localScale = new Vector3(3, 3, 3);

    }
    public void chooseweapon()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)&& flamethrowerpicked == true)
        {
            flamethrower = true;
            plasmadf = false;
            
        }
        else if( Input.GetKey(KeyCode.Alpha2))
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
