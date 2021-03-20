using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool ThreeDimensional = false;
    public GameObject Camera2D;
    public GameObject Camera3D;
    // Start is called before the first frame update
    void Start()
    {
        if (ThreeDimensional)
        {            
            Camera2D.active = false;
            Camera3D.active = true;
            GameObject.Find("ElectronGun").GetComponent<GunController>().Tilt = 0.1f;
            GameObject.Find("ElectronGun").GetComponent<GunController>().lifeTime = 10.0f;
            GameObject.Find("MagneticField").GetComponent<MagneticFieldController>().max_dim = 10;
            GameObject.Find("Target").active = false;
            GameObject.Find("Score").active = false;
            //GameObject.Find("Cannon").active = false;

        }
        else
        {
            Camera2D.active = true;
            Camera3D.active = false;
            GameObject.Find("ElectronGun").GetComponent<GunController>().Tilt = 0;
            GameObject.Find("ElectronGun").GetComponent<GunController>().lifeTime = 5.0f;
            //GameObject.Find("3DGun").active = false;
            //GameObject.Find("GunCube").active = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
