using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldController : MonoBehaviour
{
    public float FieldStrength = 1.0f;
    public GameObject fieldSpritePrefab;
    public GameObject fieldLinePrefab;

    private List<GameObject> m_sprites;
    private List<GameObject> m_fieldLines;

    public int max_dim = 5;
    // Start is called before the first frame update
    void Start()
    {
        float min_x = -3f;
        float max_x = 2f;
        float min_z = -2f;
        float max_z = 3f;
        m_sprites = new List<GameObject>();
        m_fieldLines = new List<GameObject>();
        for (int x = 0; x < max_dim; x ++)
        {
            for (int z = 0; z < max_dim; z ++)
            {
                if (x == (int)(max_dim/ 2) && z == (int)(max_dim/ 2))
                    continue;
                GameObject fieldSprite = Instantiate(fieldSpritePrefab);
                fieldSprite.transform.position = new Vector3(min_x + (float)x/ (float)(max_dim) * (max_x - min_x), 
                                                             0,
                                                             min_z + (float)z / (float)(max_dim) * (max_z - min_z));
                m_sprites.Add(fieldSprite);

                GameObject fieldLine = Instantiate(fieldLinePrefab);
                fieldLine.transform.position = new Vector3(min_x + (float)x / (float)(max_dim) * (max_x - min_x),
                                                             0,
                                                             min_z + (float)z / (float)(max_dim) * (max_z - min_z));
                m_fieldLines.Add(fieldLine);

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
        foreach (GameObject o in m_fieldLines)
        {
            FieldLineController controller = o.GetComponent<FieldLineController>();
            controller.FieldStrength = this.FieldStrength;
        }
        GameObject[] electrons = GameObject.FindGameObjectsWithTag("electron");
        foreach (GameObject e in electrons)
        {
            Rigidbody rb = e.GetComponent<Rigidbody>();
            Vector3 electron_vel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
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
