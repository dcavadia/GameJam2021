using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;

    SfxSoundSystem m_sfxSoundSystem = null;
    public GameObject reticle;
    // public Animator anim;

    void Start()
    {       
        m_sfxSoundSystem = GetComponentInChildren<SfxSoundSystem>();

        if (m_sfxSoundSystem == null) {
            Debug.Log("ObjectDetection: No se encontro el componente SfxSoundSystem");
        }
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(reticle.transform.position);

       
        // Debug.Log("Hit!");
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);

            //if (Physics.Raycast(ray, out hit))
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];



                //Debug.Log("Grabbing with E!");
                    
                // Debug.Log(hit.collider.gameObject.tag);
                bool added = false;
                bool cantAdd = false;
                switch (hit.collider.gameObject.tag)
                {
                    case "pelvis":
                        RobotPieces.AddPiece(RobotPieceId.HipAndRightFoot);
                        added = true;
                        break;
                    case "leg":
                        if (!RobotPieces.hasHipAndRightFoot)
                        {
                            RobotPieces.AddPiece(RobotPieceId.LeftFoot);
                            added = true;
                        } else {
                            cantAdd = true;
                        }
                        break;
                    case "chest":
                        if (RobotPieces.hasLeftFoot)
                        {
                            RobotPieces.AddPiece(RobotPieceId.ChestAndRightArm);
                            added = true;
                        } else {
                            cantAdd = true;
                        }
                        break;
                    case "arm":
                        if (RobotPieces.hasChestAndRightArm)
                        {
                            RobotPieces.AddPiece(RobotPieceId.LeftArm);
                            added = true;
                        } else {
                            cantAdd = true;
                        }
                        break;
                    default:
                    // RobotPieces.AddPiece(RobotPieceId.LeftArm);
                        break;
                }
                if (added) { 
                    Destroy(hit.collider.gameObject);
                    // Play sfx
                    if (m_sfxSoundSystem != null) {
                        m_sfxSoundSystem.PlayRandomClip(m_sfxSoundSystem.powerUpClips);
                    }
                }
                if (cantAdd) {
                    // Play sfx
                    if (m_sfxSoundSystem != null) {
                        m_sfxSoundSystem.PlayRandomClip(m_sfxSoundSystem.screamClips);
                    }
                }
                    
            }
        }
    }
}
