using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

//https://www.youtube.com/watch?v=5ABbo6nDm-U

public class Recoil : MonoBehaviour
{
    Automatic automatic;

    public float maxX;
    public float maxY;

    private float minX;
    private float minY;

    void Start()
    {
        automatic = gameObject.GetComponentInParent<Automatic>();
        minX = maxX * -1;
        minY = maxY * -1;
    }

    void Update()
    {
        if (automatic.fired)
        {
            Vector3 euler = transform.eulerAngles;
            euler.x = Random.Range(minX, maxX);
            euler.y = Random.Range(minY, maxY);
            transform.eulerAngles = euler;
        }
    }
}
