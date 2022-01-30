using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Character : MonoBehaviour
{
	public LayerMask layermaskBox;
	public Animator charAnimator;
	public float jumpForce;
	public float downForce;
    private bool grounded1;
    private bool grounded2;
    private bool grounded3;
    private bool grounded4;
    private bool grounded5;

	private Rigidbody rb;
	
    private InputHandler _input;

    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
		rb.AddForce(-targetVector * MovementSpeed);
		
		if (_input.InputVector.x == 0 && _input.InputVector.y == 0)
			charAnimator.SetBool("Walking", false);
		else
			charAnimator.SetBool("Walking", true);

		RaycastHit hitj;
		if (Physics.Raycast(transform.position + new Vector3(-0.75f, 0, 0), -transform.up, out hitj, 3f))
		{
            grounded1 = true;
        }
		else
            grounded1 = false;

        if (Physics.Raycast(transform.position + new Vector3(0.75f, 0, 0), -transform.up, out hitj, 3f))
        {
            grounded2 = true;
        }
        else
            grounded2 = false;

        if (Physics.Raycast(transform.position + new Vector3(0, 0, 0.75f), -transform.up, out hitj, 3f))
        {
            grounded3 = true;
        }
        else
            grounded3 = false;

        if (Physics.Raycast(transform.position + new Vector3(0, 0, -0.75f), -transform.up, out hitj, 3f))
        {
            grounded4 = true;
        }
        else
            grounded4 = false;

        if (Physics.Raycast(transform.position, -transform.up, out hitj, 3f))
        {
            grounded5 = true;
        }
        else
            grounded5 = false;

        if (grounded1 || grounded2 || grounded3 || grounded4 || grounded5)
        {
            if (Input.GetKeyDown("space"))
                rb.AddForce(Vector3.up * jumpForce);
        }
        else
            rb.AddForce(-Vector3.up * downForce);

        RaycastHit hit1;
		if (Physics.Raycast(transform.position, transform.forward, out hit1, 3, layermaskBox))
			charAnimator.SetBool("Pushing", true);
		else
			charAnimator.SetBool("Pushing", false);
        if (RotateTowardMouse)
            RotateFromMouseVector();

    }

    private void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(_input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = MovementSpeed * Time.deltaTime;
        // transform.Translate(targetVector * (MovementSpeed * Time.deltaTime)); Demonstrate why this doesn't work
        //transform.Translate(targetVector * (MovementSpeed * Time.deltaTime), Camera.gameObject.transform);

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if(movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }
}