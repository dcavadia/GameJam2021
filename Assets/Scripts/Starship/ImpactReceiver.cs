using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpactReceiver : MonoBehaviour
{
    public float thrust = 1.0f;
    Rigidbody m_rigidBody = null ;

    bool underImpactEffect = false;

    public bool UnderImpactEffect {
        get{ 
            return underImpactEffect ;
        }
    }
    public float shipRotationMagnitude = 100;
    public float shipTranslationMagnitude = 20;

    // public float impactEffectDuration = 5000;

    float secsUnderImpactEffect = 0;

    public Vector3 rotationVector ;

    Vector3 initialRotation;

    float rotationLeft = 0;

    int frame = 0;

    public int spinsAfterImpact = 2; 
    float rotationAfterImpact = 0;

    public Vector3 explosionPoint ;
    public float blastRadius;
    public float explosionPower;

    bool randomPositionApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody>();

        if (m_rigidBody == null) {
            Debug.Log("ReceiveImpact: No se encontro el componente Rigidbody");
        }

        rotationVector = Vector3.Normalize(rotationVector); 
        rotationAfterImpact = spinsAfterImpact * 360;
    }

    // Update is called once per frame
    void Update()
    {
        if (underImpactEffect) {
            bool forceLightsOn = false;
            bool forceLightsOff = false;

            frame ++;
            secsUnderImpactEffect += Time.deltaTime;

            float stopFactor = (rotationLeft) / rotationAfterImpact;

            float rotMagnitude = shipRotationMagnitude * Time.deltaTime * stopFactor;

            rotationLeft -= rotMagnitude;

            // Shake the ship
            if (frame % 2 == 0 ) {
                float translateMagnitude = shipTranslationMagnitude * Time.deltaTime * stopFactor;
                //Debug.Log(translateMagnitude.ToString());
                transform.Translate(  translateMagnitude * (frame % 4 == 0 ? Vector3.up: Vector3.down ) );
            }

            // Rotate the ship
            transform.Rotate(rotationVector * rotMagnitude);

            // Stop spins condition. Turn on lights
            if (rotationLeft < 1) {
                underImpactEffect = false;
                forceLightsOn = true;
            }


            // Split and hide the body pieces. Turn off lights
            if (stopFactor < 0.5 && !randomPositionApplied ) {
                randomPositionApplied = true;
                forceLightsOff = true;
                AddExplosionForce();
                RandomPosition randomPosition = GetComponent<RandomPosition>();
                if (randomPosition != null) {
                    randomPosition.Organizar();
                } else {
                    Debug.Log("ImpactReceiver: No se encontro el componente RandomPosition");
                }
            }
           
            Light[] lights = GetComponentsInChildren<Light>();
            foreach (Light light in lights)
            {
                if (forceLightsOn)
                // effect has ended
                    light.enabled = true;
                else if (forceLightsOff)
                    light.enabled = false;
                else 
                // blink lights
                   // light.enabled = frame % 2 == 0;
                   light.enabled = ( UnityEngine.Random.value * stopFactor < 0.25);
            }

        }
    }

    public void OnReceiveImpact () {
        Debug.Log("ImpactReceiver: Impacto recibido");
        underImpactEffect = true;
        secsUnderImpactEffect = 0;
        initialRotation = transform.localEulerAngles;
        rotationLeft = rotationAfterImpact;
        AddExplosionForce();
    }

    void AddExplosionForce () {
        Collider[] hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius);

        foreach(Collider hitCol in hitColliders) {
            Rigidbody rigidBody = hitCol.GetComponent<Rigidbody>();
            // Debug.Log("Collider found");

            if (rigidBody != null) {
                // Debug.Log("Rigid body found");
                rigidBody.AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
            }
        }
    }

  

}
