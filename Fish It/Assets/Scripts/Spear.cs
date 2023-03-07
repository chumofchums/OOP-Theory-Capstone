using UnityEngine;

public class Spear : MonoBehaviour
{
    public float destroyDepth = -5.5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fishy fish = collision.collider.GetComponent<Fishy>();
        if (fish != null)
        {
            Destroy(fish.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.y < destroyDepth)
        {
            Destroy(gameObject);
        }
    }
}
