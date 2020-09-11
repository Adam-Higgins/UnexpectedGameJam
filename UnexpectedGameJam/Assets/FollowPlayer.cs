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
    NavMeshAgent nav;

    public PlayerMovement thePlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
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
