using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;
    public GameObject Enemy;
    public GameObject Player;
    private float Distance;
    private float timer;
    private Animator animator;
    public NavMeshAgent nav;

    public PlayerMovement thePlayerMovement;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", nav.velocity.magnitude);

        Distance = Vector3.Distance(Enemy.transform.position, Player.transform.position);
        nav.SetDestination(target.position);

        if (Distance <= 3.5)
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                print("In Range");
                thePlayerMovement.Damage();
                timer = 3;
            }
            //print("In Range");
            //thePlayerMovement.Damage();
        }
    }
