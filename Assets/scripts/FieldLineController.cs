using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FieldLineController : MonoBehaviour
{
    public float FieldStrength;

    private Renderer renderer;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {

        renderer = GetComponent<Renderer>();
        scale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float height = -FieldStrength * 0.2f * scale.y;
        this.transform.localScale = new Vector3(scale.x, height, scale.z);
        this.transform.position = new Vector3(this.transform.position.x, height, this.transform.position.z);
        if (FieldStrength < 0)
            renderer.material.color = new Color(1, 0, Math.Abs(FieldStrength) / 10);
        else
            renderer.material.color = new Color(0, Math.Abs(FieldStrength) / 10, 1);
    }
}
