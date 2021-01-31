using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    public GameObject reticle;
    public Animator anim;

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
                    switch (hit.collider.name)
                    {
                        case "pelvis":
                            RobotPieces.AddPiece(RobotPieceId.HipAndRightFoot);
                            break;
                        case "leg":
                            if (!RobotPieces.hasHipAndRightFoot)
                            {
                                RobotPieces.AddPiece(RobotPieceId.LeftFoot);
                            }
                            break;
                        case "chest":
                            if (RobotPieces.hasLeftFoot)
                            {
                                RobotPieces.AddPiece(RobotPieceId.ChestAndRightArm);
                            }
                            break;
                        case "arm":
                            if (RobotPieces.hasChestAndRightArm)
                            {
                                RobotPieces.AddPiece(RobotPieceId.LeftArm);
                            }                       
                            break;
                        default:
                           // RobotPieces.AddPiece(RobotPieceId.LeftArm);
                            break;
                    }
                }
            }
        }
    }
}
