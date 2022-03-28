using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    public int minNPCSpeed;
    public int maxNPCSpeed;

    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Initial setting of variables would be done here
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;        

        System.Random r = new System.Random();
        // Movement code would be put here
        int randX = r.Next(-1,2);
        int randY = r.Next(-1,2);

        Vector2 move = new Vector2(randX, randY);
        direction = move;
        rb.velocity = move * minNPCSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * minNPCSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision triggered");
        // should we use tags for walls??
        if(collision.gameObject.tag == "InternalWall" || collision.gameObject.tag == "ExternalWall")
        {
            // walk the other way
            Debug.Log("player collided with wall!");
            direction = -1 * direction;
        }
    }

}
