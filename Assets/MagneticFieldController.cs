using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldController : MonoBehaviour
{
    public float FieldStrength = 1.0f;
    public GameObject fieldSpritePrefab;

    private List<GameObject> m_sprites;
    // Start is called before the first frame update
    void Start()
    {
        m_sprites = new List<GameObject>();
        for (int x = 0; x < 3; x ++)
        {
            for (int z = 0; z < 3; z ++)
            {
                if (x == 1 && z == 1)
                    continue;
                GameObject fieldSprite = Instantiate(fieldSpritePrefab);
                fieldSprite.transform.position = new Vector3(x - 2, 0, z - 1);
                m_sprites.Add(fieldSprite);
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.FieldStrength += 1;
            if (this.FieldStrength > 10)
            {
                this.FieldStrength = 10;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.FieldStrength -= 1;
            if (this.FieldStrength < -10)
            {
                this.FieldStrength = -10;
            }
        }

        foreach (GameObject o in m_sprites)
        {
            MagFieldSpriteController controller = o.GetComponent<MagFieldSpriteController>();
            controller.FieldStrength = this.FieldStrength;
        }
        GameObject[] electrons = GameObject.FindGameObjectsWithTag("electron");
        foreach (GameObject e in electrons)
        {
            Rigidbody rb = e.GetComponent<Rigidbody>();
            Vector3 electron_vel = rb.velocity;
            electron_vel.Normalize();
            Vector3 direction = Vector3.Cross(electron_vel, new Vector3(0, -1, 0));// new Vector3(-e.transform.position.x, 0, -e.transform.position.z);
            direction.Normalize();

            Vector3 netForce = direction * FieldStrength * 0.01f;

            Vector3 netVelocity = netForce + rb.velocity;
            netVelocity.Normalize();
            rb.velocity = rb.velocity.magnitude * netVelocity;
        }
    }
}
