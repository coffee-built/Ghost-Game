using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddForce(move, ForceMode2D.Impulse);
    }

}
