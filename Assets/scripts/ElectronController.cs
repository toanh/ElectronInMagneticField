using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronController : MonoBehaviour
{
    public float LifeTime = 2.0f;
    private Color color;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<Renderer>().material.color;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LifeTime -= Time.deltaTime;
        if (LifeTime < 0)
        {
            GameObject.Destroy(this.gameObject);
        }
        else if (LifeTime < 1.0f)
        {
            renderer.material.color = new Color(color.r * LifeTime, color.g * LifeTime, color.b * LifeTime, LifeTime);
        }
        
    }
}
