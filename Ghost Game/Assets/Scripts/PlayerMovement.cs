using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = move * playerSpeed;
    }

    public void LightAbility()
    {
        Debug.Log("Light");
    }

    public void ScreamAbility()
    {
        Debug.Log("Scream");
    }

}
