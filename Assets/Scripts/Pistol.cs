using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=THnivyG0Mvo

public class Pistol : MonoBehaviour
{
	public float damage = 10f;
	public float range = 100f;
	public ParticleSystem flash;
	public Camera fpsCam;
	public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
    }

	void Shoot()
	{
		flash.Play();
		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			Target target = hit.transform.GetComponent<Target>();
			if(target != null)
			{
				target.TakeDamage(damage);
			}

			GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impact, 2f);
		}
	}
}
