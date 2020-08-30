using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedHeight;
   
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;

    }

    // Update is called once per frame
    void Update()
    {
        //Crouch;
        if (Input.GetKeyDown(KeyCode.C))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.C))
            GoUp();
    }

    //Method to reduce height;
    void Crouch() 
    {
        playerCol.height = reducedHeight;
    }

    //Method to reset height;
    void GoUp()
    {
        playerCol.height = originalHeight;
    }
}
// Author: Evan
// 7:36 P.M. 5/24/2020
//https://www.youtube.com/watch?v=qr5yMmUOwDc
