using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    public GameObject reticle;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(reticle.transform.position);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "BodyPart")
            {
                Debug.Log("Pieza!");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Agarrado!");
                }
            }
        }
    }
}
