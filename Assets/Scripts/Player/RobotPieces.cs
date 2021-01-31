using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPieces : MonoBehaviour
{    public static bool hasHipAndRightFoot = true;
    public static bool hasLeftFoot = true;
    public static bool hasChestAndRightArm = true;
    public static bool hasLeftArm = true;
    
    RandomPosition m_randomPosition;

    public static TimerController timerController;
    
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
            hasHipAndRightFoot = false;
            hasLeftFoot = false;
            hasChestAndRightArm = false;
            hasLeftArm = false;
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
            case RobotPieceId.HipAndRightFoot:
                hasHipAndRightFoot = true;
                break;
            case RobotPieceId.LeftFoot:
                hasLeftFoot = true;
                break;
            case RobotPieceId.ChestAndRightArm:
                 hasChestAndRightArm = true;
                break;
            case RobotPieceId.LeftArm:
                hasLeftArm = true;
                timerController.WinGame();
                break;
            default:
                break;
        }
    }
}
