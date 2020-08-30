using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour
{


	public bool isgrounded;
	public bool jump;
	public bool timer;
	private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    #region MonoBehaviour API

    public float rotationRate = 360;

    public float moveSpeed = 2;
	Animator anim;
	CharacterController controller;

	private void Start()
	{
		isgrounded = true;
		anim = GetComponent<Animator>();
		jump = false;
		timer = false;
	}

	void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);
		int animInt = anim.GetInteger("condition");
		ApplyInput(moveAxis, turnAxis);

		//debugging
		Debug.Log("Grounded = " + isgrounded);
		Debug.Log("Jump = " + jump);
		Debug.Log("Condition = " + animInt);
		Debug.Log("Timer = " + timer);

		if (Input.GetKey(KeyCode.W) && !jump)
		{
			anim.SetInteger("condition", 1);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}
		else if(!jump)
		{
			anim.SetInteger("condition", 0);
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}
		else if(jump && isgrounded && animInt == 2 && timer){
			notJump();
			timer = false;
			
		}
	}

	private void notJump()
	{
		anim.SetInteger("condition", 3);
		jump = false;
	}

	private void Jump()
	{
		if (isgrounded)
		{
			jump = true;
			GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
			anim.SetInteger("condition", 2);
			StartCoroutine(JumpCoroutine());
		}
	}

	IEnumerator JumpCoroutine()
	{
		yield return new WaitForSeconds(0.1f);
		timer = true;
	}
	

	private void ApplyInput(float moveInput,
                            float turnInput)
    {
		Move(moveInput);
        Turn(turnInput);
	}
    
    private void Move(float input) 
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
	}

    private void Turn(float input)
    {
        transform.Translate(Vector3.right * input * moveSpeed);
    }

	void OnCollisionEnter(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "ground")
		{
			isgrounded = true;
		}
	}

	void OnCollisionExit(Collision theCollision)
	{
		if (theCollision.gameObject.tag == "ground")
		{
			isgrounded = false;
		}
	}


	// Made by Evan 
	// 2:34 AM 2/19/2020
	//Modified for jumps 2:03 Am 2/21/2020
	//Link to video used:
	//https://www.youtube.com/watch?v=3uOdm2wt43E
}
#endregion