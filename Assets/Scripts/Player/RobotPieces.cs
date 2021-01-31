using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPieces : MonoBehaviour
{

    public static bool hasChestAndRightArm = false;
    public static bool hasLeftArm = false;
    public static bool hasHipAndRightFoot = false;
    public static bool hasLeftFoot = false;
    
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
        } else {
            Debug.Log("ImpactReceiver: No se encontro el componente RandomPosition");
        }
    }

    //Set animation and switch of robot here:
    public static void AddPiece(RobotPieceId piece)
    {
        Debug.Log("Agarrado!");
        switch (piece)
        {
            case RobotPieceId.LeftFoot:
                break;
            case RobotPieceId.HipAndRightFoot:
                break;
            case RobotPieceId.ChestAndRightArm:
                break;
            case RobotPieceId.LeftArm:
                break;
            default:
                break;
        }
    }
}
