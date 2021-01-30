using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPieces : MonoBehaviour
{

    public bool hasChestAndRightArm = true;
    public bool hasLeftArm = true;
    public bool hasHipAndRightFoot = true;
    public bool hasLeftFoot = true;
    
    RandomPosition m_randomPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        m_randomPosition = GetComponent<RandomPosition>();

        if(m_randomPosition == null) {
            Debug.Log("RobotPieces: No se encontro el componente RandomPosition");
        }

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void SplitPieces () {
        if (m_randomPosition != null) {
            m_randomPosition.Organizar();
            hasChestAndRightArm =false;
            hasLeftArm =false;
            hasHipAndRightFoot =false;
            hasLeftFoot =false;
        } else {
            Debug.Log("ImpactReceiver: No se encontro el componente RandomPosition");
        }
    }
}
