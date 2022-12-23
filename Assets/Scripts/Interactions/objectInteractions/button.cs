using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : Interactable
{
    [SerializeField]private GameObject door;
    private bool doorOpen;
    
    protected override void Interact()
    {
        doorOpen = !doorOpen;

        door.GetComponent <Animator>().SetBool("isOpen", doorOpen);
        if (doorOpen)
        {
            door.transform.GetComponentInChildren<Collider>().enabled = false;
        }
        else
        {
            door.transform.GetComponentInChildren<Collider>().enabled = true;
        }
        
    }
}
