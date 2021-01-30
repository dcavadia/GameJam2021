using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpactReceiver : MonoBehaviour
{
    public float thrust = 1.0f;
    Rigidbody m_rigidBody = null ;

    bool underImpactEffect = false;
    public float shipRotationMagnitude = 50;
    public float shipTranslationMagnitude = 52;

    // public float impactEffectDuration = 5000;

    float secsUnderImpactEffect = 0;

    public Vector3 rotationVector ;

    Vector3 initialRotation;

    float rotationLeft = 0;

    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = gameObject.GetComponent<Rigidbody>();

        if (m_rigidBody == null) {
            Debug.Log("ReceiveImpact: No se encontro el componente Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (underImpactEffect) {
            frame ++;
            secsUnderImpactEffect += Time.deltaTime;
            float rotMagnitude = shipRotationMagnitude * Time.deltaTime;

            rotationLeft -= rotMagnitude;

            // Shake the ship
            transform.Translate(  shipTranslationMagnitude * Time.deltaTime * (frame % 2 == 0 ? Vector3.up: Vector3.down )
                / secsUnderImpactEffect
            );

            // Rotate the ship
            transform.Rotate(rotationVector * rotMagnitude);

            // Stop after a full spin
            if (rotationLeft < 1) {
                underImpactEffect = false;
            }

           
            Light[] lights = GetComponentsInChildren<Light>();
            foreach (Light light in lights)
            {
                if (!underImpactEffect)
                // effect has ended
                    light.enabled = true;
                else 
                // blink lights
                    light.enabled = frame % 2 == 0;
            }

        }
    }

    public void OnReceiveImpact () {
        Debug.Log("ImpactReceiver: Impacto recibido");
        underImpactEffect = true;
        secsUnderImpactEffect = 0;
        initialRotation = transform.localEulerAngles;
        rotationLeft = 360;
    }

}
