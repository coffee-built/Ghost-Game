using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    private Rigidbody2D rb;

    private bool currentlyFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = move * playerSpeed;

        if ((move[0] > 0 && !currentlyFacingRight) || (move[0] < 0 && currentlyFacingRight)) Flip();
    }

    public void LightAbility()
    {
        Debug.Log("Light");
    }

    public void ScreamAbility()
    {
        Debug.Log("Scream");
    }

    void Flip()
    {
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
