using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : MonoBehaviour
{

    StarShipHull m_starShipHull = null;
    // Start is called before the first frame update
    void Start()
    {
        m_starShipHull = GetComponentInChildren<StarShipHull>();

        if (m_starShipHull == null) {
            Debug.Log("StarShip: No se encontro el componente StarShipHull");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCameraEnter() {
        // Debug.Log("OnCameraEnter");
        if (m_starShipHull != null) {
            m_starShipHull.OnCameraEnter();
        }
    }
}
