using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Movement : MonoBehaviour
{
    private Animator animator;
    private string currentAnimationState;
    private Rigidbody2D rb;
    public int minNPCSpeed;
    public int maxNPCSpeed;

    [SerializeField] Transform target;
    NavMeshAgent agent;

    private Vector2 directionVector;
    private int[,] directionsArray = new int[,] {{ 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
    // TO-DO: update animations (separate left, right or flip using code)
    private string[] directionNames = new string[] { "npc_body5_walk_front" , "npc_body5_walk_side", "npc_body5_walk_front" , "npc_body5_walk_side"};
    private bool currentlyFacingRight = true;

    public int framesTillDirectionSwitchAllowed;
    private int currentFramesSinceLastDirectionSwitch;
    private bool currentlyExecutingMovement;
    private Vector3 nextDesiredPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentlyExecutingMovement = false;
        currentFramesSinceLastDirectionSwitch = framesTillDirectionSwitchAllowed;

        if (target != null)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.angularSpeed = 0;
        }

        // Initial setting of variables would be done here
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;        

        animator.Play("npc_body_idle_front");

        System.Random r = new System.Random();
        // Movement code would be put here
        // int randX = r.Next(-1,2);
        // int randY = r.Next(-1,2);
        // Vector2 move = new Vector2(randX, randY);
        int d = r.Next(0,4);
        Vector2 move = new Vector2(directionsArray[d,0], directionsArray[d,1]);
        ChangeAnimationState(d);
        
        directionVector = move;
        rb.velocity = move * minNPCSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (currentFramesSinceLastDirectionSwitch < framesTillDirectionSwitchAllowed)
            {
                Debug.Log(agent.desiredVelocity);
                //if (nextDesiredPosition == agent.transform.position)
                if (Math.Abs(nextDesiredPosition.x - agent.transform.position.x) < 0.2
                    || Math.Abs(nextDesiredPosition.y - agent.transform.position.y) < 0.2)
                {
                    currentFramesSinceLastDirectionSwitch = framesTillDirectionSwitchAllowed;
                }
                else currentFramesSinceLastDirectionSwitch += 1;
            }
            else
            {
                Debug.Log("Switching");
                currentFramesSinceLastDirectionSwitch = 0;

                agent.isStopped = false;
                agent.SetDestination(target.position);

                var desiredDirection = agent.desiredVelocity;
                desiredDirection.z = 0f;
                string nextAnimationState = directionNames[0];

                if (Math.Abs(desiredDirection.x) > Math.Abs(desiredDirection.y))
                {
                    Debug.Log("Horizontal Movement");
                    //Move horizontally
                    desiredDirection.y = 0f;
                    nextAnimationState = desiredDirection.x > 0 ? directionNames[1] : directionNames[3];
                }
                else
                {
                    Debug.Log("Vertical Movement");
                    //Move vertically
                    desiredDirection.x = 0f;
                    nextAnimationState = desiredDirection.x > 0 ? directionNames[0] : directionNames[2];
                }

                nextDesiredPosition = agent.transform.position + desiredDirection;
                //agent.SetDestination(nextDesiredPosition);

                if ((desiredDirection[0] > 0 && !currentlyFacingRight) || (desiredDirection[0] < 0 && currentlyFacingRight)) Flip();

                if (currentAnimationState == nextAnimationState) return;

                animator.Play(nextAnimationState);
                currentAnimationState = nextAnimationState;

                directionVector = desiredDirection;
                rb.velocity = desiredDirection * minNPCSpeed;
            }
        }

        else RandomUpdateDirection();

        //rb.velocity = directionVector * minNPCSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision triggered");
        // should we use tags for walls??
        if(collision.gameObject.tag == "InternalWall" || collision.gameObject.tag == "ExternalWall")
        {
            // walk the other way
            //Debug.Log("player collided with wall!");
            directionVector = -1 * directionVector;
            Flip();
            rb.velocity = directionVector * minNPCSpeed;
        }
    }

    void ChangeAnimationState(int d)
    {
        string nextAnimationState = directionNames[d];
        if (currentAnimationState == nextAnimationState) return;
        
        animator.Play(nextAnimationState);
        currentAnimationState = nextAnimationState;
    }

    void RandomUpdateDirection()
    {

        System.Random r = new System.Random(Guid.NewGuid().GetHashCode()); //TODO: Probably not the best way to do this, figure out a less performance heavy alternative
        int d = r.Next(0,1000);
        if (d > 3) return;

        Vector2 move = new Vector2(directionsArray[d,0], directionsArray[d,1]);
        if ((move[0] > 0 && !currentlyFacingRight) || (move[0] < 0 && currentlyFacingRight)) Flip();
        ChangeAnimationState(d);
        
        directionVector = move;
        rb.velocity = move * minNPCSpeed;

    }

    void Flip()
    {
        //Debug.Log("Flipping");
        Vector3 currentScale = rb.transform.localScale;
        currentScale.x *= -1;
        rb.transform.localScale = currentScale;
        currentlyFacingRight = !currentlyFacingRight;

        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 currentChildScale = transform.GetChild(i).localScale;
            currentChildScale.x *= -1;
            transform.GetChild(i).localScale = currentChildScale;
        }
    }

}
