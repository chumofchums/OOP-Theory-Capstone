using UnityEngine;

public class Fishy : MonoBehaviour
{

    public Vector3 targetPosition;
    private float speed = 2f;
    public float targetPositionX = 5f;
    private float minY = -4f;
    private float maxY = 1f;
    private float clampValue = 2f;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // ABSTRACTION
        Swim();

        UpdateTargetPosition();
        FlipSprite();
    }

    // POLYMORPHISM
    public virtual void Swim()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public virtual void UpdateTargetPosition()
    {
        // Calculate a new random position if the fish has reached the targetPosition
        if (transform.position == targetPosition)
        {
            // Generate a new random Y position between -4 & +1 
            float randomY = Mathf.Clamp(Random.Range(-clampValue, clampValue), minY, maxY);
            targetPosition = new Vector3(Random.Range(-targetPositionX, targetPositionX), randomY, 0f);
        }
    }

    private void FlipSprite()
    {
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
}
