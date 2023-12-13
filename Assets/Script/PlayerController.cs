using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        targetPosition.z = 0f;

        Vector2 direction = (targetPosition - transform.position).normalized;

        playerRigidbody.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
     
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
