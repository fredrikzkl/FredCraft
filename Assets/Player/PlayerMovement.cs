using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 4f;

    public GameObject groundChecker;
    
    public float groundCheckerRadius = 1f;

    //Temps
    float fallingSpeed;


    void Start()
    {
        
    }
     
    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundChecker.transform.position, groundCheckerRadius, LayerMask.GetMask("Ground"));

        if (isGrounded)
            fallingSpeed = 0;
        else
            AffectedByGravity();


        
        
        if (Input.GetButtonDown("Horizontal"))
        {
            
        }
        if (Input.GetButtonDown("Vertical"))
        {

        }


    }

    void AffectedByGravity()
    {
        //fallingSpeed = 
    }

    
}
