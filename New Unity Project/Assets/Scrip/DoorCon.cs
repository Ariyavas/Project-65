using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCon : MonoBehaviour
{
public bool doorOpen = false;
public GameObject Door;
Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("DoorOpen", doorOpen);
    }
}
