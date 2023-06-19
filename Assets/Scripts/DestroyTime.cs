using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    public float leftTime;
    void Start()
    {
        Destroy(gameObject, leftTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
