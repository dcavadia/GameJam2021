
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : AstronomicalBody
{
    public float thrust = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }

    void OnCollisionEnter(Collision collision)
    {       
        ImpactReceiver impactReceiver = collision.gameObject.GetComponentInChildren<ImpactReceiver>();
        if (impactReceiver != null) {
            impactReceiver.OnReceiveImpact();
        } else {
            Debug.Log("Asteroid: No se encontro el componente ImpactReceiver");
        }
        Destroy(gameObject);
    }

}
