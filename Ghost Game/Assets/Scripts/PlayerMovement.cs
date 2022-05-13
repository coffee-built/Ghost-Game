using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;

    private Rigidbody2D rb;
    private ParticleSystem playerAbilityParticleSystem;
    private SpriteRenderer playerSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        playerSprite.flipX = false;
    }


    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = move * playerSpeed;

        if ((move[0] > 0 && playerSprite.flipX) || (move[0] < 0 && !playerSprite.flipX)) Flip();
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
        playerSprite.flipX = !playerSprite.flipX;
    }

}
