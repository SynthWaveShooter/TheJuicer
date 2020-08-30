using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour
{
	public float damage = 10f;
	public float range = 100f;
	public ParticleSystem flash;
	public Camera fpsCam;
	public ParticleSystem bullet;
	public Boolean fired = false;
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Fire1"))
		{
			Shoot();
        }
        else
        {
			fired = false;
			bullet.Stop();
        }
	}

	void Shoot()
	{
		fired = true;
		flash.Play();
		bullet.Play();
	}
}
