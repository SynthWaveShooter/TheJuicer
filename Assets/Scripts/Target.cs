using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//https://www.youtube.com/watch?v=THnivyG0Mvo
//https://www.youtube.com/watch?v=fKWTpi70a_E

public class Target : MonoBehaviour
{
	public float health = 50f;
	public Transform[] target;
	public float speed;
	private int current;

	void OnParticleCollision(GameObject other)
	{
		TakeDamage(5);
	}

	void Update()
    {
		transform.Rotate(0, 0, 50 * Time.deltaTime);
		Debug.Log("Current: " + current);
		if(transform.position != target[current].position)
        {
			Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
			GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
			if (current == target.Length - 1)
			{
				current = 0;
			}
			else current = (current + 1) % target.Length;
			
        }
    }

	public void TakeDamage(float amount)
	{
		health -= amount;
		if(health <= 0f)
		{
			Die();
		}
	}
	
	void Die()
	{
		Destroy(gameObject);
	}
}
