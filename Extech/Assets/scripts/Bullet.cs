﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool isPlasma = false;
    public bool isFire = false;

    public float plasmaDamage;
    public float fireDamage;

    public GameObject plasmaImpactEffect;
    public GameObject fireImpactEffect;

    float damageToDeal = 0f;

    public float burnDamage = 5f;
    public float burnTime = 5f;
    public int burnTickRate = 1;

    character _charater;

    private void Start()
    {
        if(isPlasma)
        {
            damageToDeal = plasmaDamage;
        }
        else if(isFire)
        {
            damageToDeal = fireDamage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            _charater = other.gameObject.GetComponent<character>();

            if (_charater != null)
            {
                hitEnemy();
            }
        }
        else
        {
            if(other.gameObject.GetComponent<MeshRenderer>() != null && other.gameObject.GetComponent<MeshRenderer>().enabled && !isFire)
            {
                Instantiate(plasmaImpactEffect, transform.position, transform.rotation);
            }
        }
    }

    public void hitEnemy()
    {
        if (isPlasma)
        {
            if (plasmaImpactEffect != null)
            {
                Instantiate(plasmaImpactEffect, transform.position, transform.rotation);
            }

            _charater.takeDamage(damageToDeal);
        }
        else if (isFire)
        {
            _charater.setOnFire(fireImpactEffect, burnTime, burnDamage, burnTickRate);
        }

        Destroy(this.gameObject);
    }


}
