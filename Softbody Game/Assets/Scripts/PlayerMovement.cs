using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 castSize;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask groundLayer;

    public float speed = 4.5f;
    public float jumpforce = 75f;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.linearVelocity.y);
        body.linearVelocity = movement;

        if (GroundedCheck() == true && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

    private bool GroundedCheck()
    {
        if (Physics2D.BoxCast(transform.position, castSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - transform.up * castDistance, castSize);
    }
}
