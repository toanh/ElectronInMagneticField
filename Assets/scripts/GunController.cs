using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed = 10f;
    public float lifeTime = 10f;
    public float Tilt = 0f;
    public bool AutoFire = false;

    private float Timer;
    private float ShootRate = 0.1f;

    void Start()
    {
        Timer = ShootRate;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !AutoFire)
        {
            Fire();
        }
        else if (AutoFire)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = ShootRate;
                Fire();
            }
        }
        Vector3 arrowDirection = new Vector3(0, 0, 1);
        Vector3 pos = projectileSpawn.position;
        float arrowHeadLength = 0.5f;

        float arrowHeadAngle = 45.0f;
        Color color = new Color(0.2F, 0.3F, 0.4F);
        Debug.DrawRay(pos, arrowDirection, color);

        Vector3 right = Quaternion.LookRotation(arrowDirection) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Vector3 left = Quaternion.LookRotation(arrowDirection) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
        Debug.DrawRay(pos + arrowDirection, right * arrowHeadLength, color);
        Debug.DrawRay(pos + arrowDirection, left * arrowHeadLength, color);
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = projectileSpawn.position;
        projectile.GetComponent<Rigidbody>().velocity = new Vector3(0, Tilt, 1) * projectileSpeed;

        projectile.GetComponent<ElectronController>().LifeTime = lifeTime;
    }

}
