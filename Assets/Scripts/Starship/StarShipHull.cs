using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShipHull : MonoBehaviour
{
    MeshRenderer[] m_meshRenderers = null;
    // Start is called before the first frame update
    void Start()
    {
        m_meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCameraEnter() {
        // Desactiva el casco de la nave
        foreach( MeshRenderer  m_meshRenderers in m_meshRenderers) {
            m_meshRenderers.enabled = false;
        }
    }
}
