using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetController : MonoBehaviour
{
    private GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(1.0f, 1.0f, 1.0f);
    }

    void OnTriggerEnter(Collider c)
    {
        //Debug.Log(c);
        score.GetComponent<ScoreController>().Score += 1;
        GameObject.Destroy(c.gameObject);

        System.Random rand = new System.Random();// r.Next(-2.f, 2.f), 0, r.Next(-2.f, 2.f));
        this.transform.position = new Vector3((float)rand.NextDouble() * 2.4f - 2.2f, 0, (float)rand.NextDouble() * 2.4f - 1.2f);
        
    }
}
