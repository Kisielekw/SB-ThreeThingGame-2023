using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckzillaAnimations : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idling", false);
            animator.SetBool("Punching", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idling", false);
            animator.SetBool("Punching", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idling", false);
            animator.SetBool("Punching", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Idling", false);
            animator.SetBool("Punching", false);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idling", false);
            animator.SetBool("Punching", true);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idling", false);
            animator.SetBool("Punching", false);
            animator.SetBool("Dancing", true);
        }
        else
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idling", true);
            animator.SetBool("Punching", false);
        }
    }
}
