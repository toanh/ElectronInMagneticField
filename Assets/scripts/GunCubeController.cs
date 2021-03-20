using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunCubeController : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.gameObject.GetComponent<Renderer>().material.color = new Color(1.0f - (float)Math.Sin(2 * time), (float)Math.Sin(2 * time), (float)Math.Cos(2 * time));
        this.transform.Rotate(new Vector3(1.0f, 1.0f, 1.0f));
    }
}
