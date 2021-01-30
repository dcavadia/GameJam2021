
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : AstronomicalBody
{
    Rigidbody m_rigidBody = null ;
    public Vector3 initialForceDirection  = Vector3.down;
    public float initialForceMagnitude = 1;
    public ForceMode initialForceMode;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody>();

        if (m_rigidBody == null) {
            Debug.Log("Asteroid: No se encontro el componente Rigidbody");
        } else {
            //Debug.Log("Asteroid: adding force");
            // m_rigidBody.AddForce(initialForceDirection * initialForceMagnitude, initialForceMode);
        }
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void AddInitialForce() {
        if (m_rigidBody == null) {
            Debug.Log("Asteroid: No se encontro el componente Rigidbody");
        } else {
            //Debug.Log("Asteroid: adding force");
            m_rigidBody.AddForce(initialForceDirection * initialForceMagnitude, initialForceMode);
        }
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
