using UnityEngine;

public class Fishy : MonoBehaviour
{

    private Vector3 targetPosition;
    private float speed = 2f;
    private float maxX = 5f;
    private float minX = -5f;
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
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        UpdateTargetPosition();
        FlipSprite();
    }

    public virtual void UpdateTargetPosition()
    {
        // Calculate a new random position if the fish has reached the target
        if (transform.position == targetPosition)
        {
            // Generate a new random Y position between -4 & +1 
            float randomY = Mathf.Clamp(Random.Range(-clampValue, clampValue), minY, maxY);
            targetPosition = new Vector3(Random.Range(minX, maxX), randomY, 0f);
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
