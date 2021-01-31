using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAnimations : MonoBehaviour
{
    Animator thisAnim = default;
    // Start is called before the first frame update
    void Start()
    {
        thisAnim = gameObject.GetComponent<Animator>();
    }

    public  void onSelect()
    {
        if ( !thisAnim ) thisAnim = gameObject.GetComponent<Animator>();
        thisAnim.SetBool("selected", true);
    }

    public void onDeselect()
    {
        if ( !thisAnim ) thisAnim = gameObject.GetComponent<Animator>();
        thisAnim.SetBool("selected", false);
    }
}
