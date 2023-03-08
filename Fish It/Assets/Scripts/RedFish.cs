using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFish : Fishy
{
    [SerializeField] float redSpeed = 2.5f;

    // POLYMORPHISM
    public override void Swim()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, redSpeed * Time.deltaTime);
    }

    public override void UpdateTargetPosition()
    {
        // Calculate a new random position if the fish has reached the targetPosition
        if (transform.position == targetPosition)
        {
            // Generate a new random Y position between -4 & +1 
            float randomY = Mathf.Clamp(Random.Range(-2, 2), -4, -1);
            targetPosition = new Vector3(Random.Range(-targetPositionX, targetPositionX), randomY, 0f);
        }
    }
}
