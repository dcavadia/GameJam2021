using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator _doorAnim;
    [SerializeField] public AudioClip open, close;
    public AudioSource door;

    private void OnTriggerEnter(Collider other)
    {
        _doorAnim.SetBool("isOpening", true);
        door.PlayOneShot(open);
    }
    private void OnTriggerExit(Collider other)
    {
        _doorAnim.SetBool("isOpening", false);
        door.PlayOneShot(close);
    }
    // Start is called before the first frame update
    void Start()
    {
        _doorAnim = this.transform.parent.GetComponent<Animator>();
        door = this.transform.parent.GetComponentInParent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
