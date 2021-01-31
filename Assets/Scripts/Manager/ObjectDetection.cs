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
                        case "arm":
                            if (RobotPieces.hasChestAndRightArm)
                            {
                                RobotPieces.AddPiece(RobotPieceId.LeftArm);
                            }                       
                            break;
                        case "chest":
                            if (RobotPieces.hasHipAndRightFoot)
                            {
                                RobotPieces.AddPiece(RobotPieceId.ChestAndRightArm);
                            }
                            break;
                        case "leg":
                            if (!RobotPieces.hasLeftFoot)
                            {
                                RobotPieces.AddPiece(RobotPieceId.LeftFoot);
                            }
                            break;
                        case "pelvis":
                            if (RobotPieces.hasLeftFoot)
                            {
                                RobotPieces.AddPiece(RobotPieceId.HipAndRightFoot);
                            }
                            break;
                        default:
                            RobotPieces.AddPiece(RobotPieceId.LeftArm);
                            break;
                    }
                }
            }
        }
    }
}
