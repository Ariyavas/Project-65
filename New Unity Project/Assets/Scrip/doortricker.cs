using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doortricker : MonoBehaviour
{
    public DoorCon door;
    public bool playerStay = false;
    public GameObject canvas;

    private void Update()
    {
        canvas.SetActive(playerStay);
        if(playerStay && Input.GetKeyDown(KeyCode.E))
        {
            door.doorOpen = !door.doorOpen;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Body")
        {
            playerStay = true;
        }
    }   

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Body")
        {
            playerStay = false;
        }
    }
    
}
