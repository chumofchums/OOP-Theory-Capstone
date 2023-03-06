using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed = 2f;
    public float maxRotation = 45f;
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        targetPosition = transform.position;
        targetRotation = transform.rotation;
    }

    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        UpdateTargetPosition();
        UpdateTargetRotation();

        // Check if the fish is moving in the negative x direction
        if (transform.position.x < targetPosition.x)
        {
            // Flip the sprite horizontally
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void UpdateTargetPosition()
    {
        // Calculate a new random position if the fish has reached the target
        if (transform.position == targetPosition)
        {
            // Generate a new random position, clamping the Y coordinate to the range [-4, 1]
            float randomY = Mathf.Clamp(Random.Range(-2f, 2f), -4f, 1f);
            targetPosition = new Vector3(Random.Range(-5f, 5f), randomY, 0f);
        }
    }


    private void UpdateTargetRotation()
    {
        // Calculate the direction the fish is moving in
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // If the fish is moving left, adjust the angle
        if (direction.x < 0f)
        {
            angle += 180f;
        }

        // Determine the direction the fish is currently facing
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180f)
        {
            currentAngle -= 360f;
        }

        // Determine the angle between the fish's current direction and its movement direction
        float deltaAngle = Mathf.DeltaAngle(currentAngle, angle);

        // Adjust the target rotation based on the delta angle
        if (deltaAngle > maxRotation)
        {
            deltaAngle = maxRotation;
        }
        else if (deltaAngle < -maxRotation)
        {
            deltaAngle = -maxRotation;
        }
        targetRotation = Quaternion.Euler(0f, 0f, currentAngle + deltaAngle);
    }


}