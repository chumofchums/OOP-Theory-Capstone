using UnityEngine;

public class FishBase : MonoBehaviour
{
    public float speed = 2f;
    public float maxRotation = 10f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        targetPosition = transform.position;
        targetRotation = transform.rotation;
    }

    protected virtual void Update()
    {
        UpdateTargetPosition();
        UpdateTargetRotation();
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotation * Time.deltaTime);
    }

    private void UpdateTargetPosition()
    {
        if (transform.position == targetPosition)
        {
            float randomY = Random.Range(-4f, 1f);
            targetPosition = new Vector3(Random.Range(-5f, 5f), randomY, 0f);
        }
    }

    private void UpdateTargetRotation()
    {
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (direction.x < 0f)
        {
            angle += 180f;
        }
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180f)
        {
            currentAngle -= 360f;
        }
        float deltaAngle = Mathf.DeltaAngle(currentAngle, angle);
        if (deltaAngle > maxRotation)
        {
            deltaAngle = maxRotation;
        }
        else if (deltaAngle < -maxRotation)
        {
            deltaAngle = -maxRotation;
        }
        targetRotation = Quaternion.Euler(0f, 0f, currentAngle + deltaAngle);
        if (direction.x < 0f)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}
