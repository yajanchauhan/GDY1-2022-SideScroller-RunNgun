using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCcontroller : MonoBehaviour
{
    public float movementSpeed = 1f;
    public enum States
	{
        idle,
        run
	}

    States state;
    void Start()
    {
        state = States.idle;
    }


    // Update is called once per frame
    void Update()
    {
        // This is the state machine for the PC

        switch (state) // A switch statement tests one variable (the variable that is after the switch keyword and inside parentheses)
                       // against different values. Each value is stated after a "case" keyword. 
                       // A "case" block of instructions is between the ":" sign and "break" keyword. 
                       // This case block of instructions is executed when the variable tested is equal to the value after the case keyword.
		{
            case States.idle:
                DoinIdleState();
                break;

            case States.run:
                DoInRunState();
                break;
        }
    }

	private void DoinIdleState()
	{
        if (Input.GetAxis("Horizontal")==0)
		{
            Debug.Log("idle");
		}
        else
		{
            state = States.run;
        }
       
    }

	// It moves the character left or right based on input(s)
	void DoInRunState() 
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            state = States.idle;
        }


        float movement = Input.GetAxis("Horizontal");
       transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        //transform.position = transform.position + new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed; is the same as previous line 
        //transform.Translate(new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed);
    }
}
