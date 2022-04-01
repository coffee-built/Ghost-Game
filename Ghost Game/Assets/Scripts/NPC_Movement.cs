using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    private Animator animator;
    private string currentAnimationState;
    private Rigidbody2D rb;
    public int minNPCSpeed;
    public int maxNPCSpeed;

    private Vector2 directionVector;
    private int[,] directionsArray = new int[,] {{ 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
    // TO-DO: update animations (separate left, right or flip using code)
    private string[] directionNames = new string[] { "npc_body_walk_front" , "npc_body_walk_side", "npc_body_walk_front" , "npc_body_walk_side"};

    // Start is called before the first frame update
    void Start()
    {
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

        // TO-DO: add real path planning instead here
        RandomUpdateDirection();


        // rb.velocity = directionVector * minNPCSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision triggered");
        // should we use tags for walls??
        if(collision.gameObject.tag == "InternalWall" || collision.gameObject.tag == "ExternalWall")
        {
            // walk the other way
            Debug.Log("player collided with wall!");
            directionVector = -1 * directionVector;
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

        System.Random r = new System.Random();
        int d = r.Next(0,1000);
        if (d > 3) return;
        
        Vector2 move = new Vector2(directionsArray[d,0], directionsArray[d,1]);
        ChangeAnimationState(d);
        
        directionVector = move;
        rb.velocity = move * minNPCSpeed;
    }

}
