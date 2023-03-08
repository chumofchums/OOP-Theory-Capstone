using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GreenFish : Fishy
{

    [SerializeField] float greenSpeed = 3f;

    private float greenMinY = -4;
    private float greenMaxY = -2;
    

    // POLYMORPHISM
    public override void Swim()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, greenSpeed * Time.deltaTime);
    }

    public override void UpdateTargetPosition()
    {
        // Calculate a new random position if the fish has reached the targetPosition
        if (transform.position == targetPosition)
        {
            // Generate a new random Y position between -4 & +1 
            float randomY = Mathf.Clamp(Random.Range(-2, 2), greenMinY, greenMaxY);
            targetPosition = new Vector3(Random.Range(-targetPositionX, targetPositionX), randomY, 0f);
        }
    }
}
