using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float moveSpeed = 100f;
    public float turnSpeed = 5f;
    Quaternion characterTargetRotation;
    public float XSensitivity;

    private int health;
    public Vector3 playerStartPoint;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       characterTargetRotation = transform.rotation;
        health = 5;
        playerStartPoint = transform.position;

    }

    // Update is called once per frame
    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        Vector3 frd = vertical * transform.forward;
        Vector3 rgt = horizontal * transform.right;



        //characterTargetRotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * XSensitivity, 0f);
       // transform.rotation = characterTargetRotation;

        var movement = (frd + rgt);


        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        animator.SetFloat("Speed", movement.magnitude);


        /*if (movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        } */

    }
    public void Damage()
    {
        //print("Function Running");
        // StartCoroutine("DamageCo");
        health = health - 1;
        print(("Health is", health));
        Debug.Log(transform.position);

        if (health < 1)
        {
            gameObject.SetActive(false);
            print("The heavy is dead");
            health = 5;
            transform.position = playerStartPoint;
            gameObject.SetActive(true);

        }
        //DamageCo();
    }
}
