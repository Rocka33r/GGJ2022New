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
        //var movementVector = MoveTowardTarget(targetVector);
		
		if (_input.InputVector.x == 0 && _input.InputVector.y == 0)
			charAnimator.SetBool("Walking", false);
		else
			charAnimator.SetBool("Walking", true);

		
		RaycastHit hitj;
		if (Physics.Raycast(transform.position, -Vector3.up, out hitj, 3f))
		{
			if (Input.GetKeyDown("space"))
			{
				rb.AddForce(Vector3.up * jumpForce);
			}
		}
		else
			rb.AddForce(-Vector3.up * downForce);
		
		RaycastHit hit1;
		if (Physics.Raycast(transform.position, transform.forward, out hit1, 3, layermaskBox))
		{
			charAnimator.SetBool("Pushing", true);
		}
		else
		{
			charAnimator.SetBool("Pushing", false);
		}

        //if (!RotateTowardMouse)
        //{
            //RotateTowardMovementVector(movementVector);
        //}
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }

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