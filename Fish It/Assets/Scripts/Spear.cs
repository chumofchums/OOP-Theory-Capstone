using UnityEngine;

public class Spear : MonoBehaviour
{
    public float destroyDepth = -5.5f;
    public float waterDrag = 1f;
    public float defaultDrag = 0f;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fishy fish = collision.collider.GetComponent<Fishy>();
        if (fish != null)
        {
            SoundManager.Instance.OnFishDeath();
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

        // Add drag once it gets below 2Y/ aka enters the water
        if (transform.position.y < 2f)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.drag = waterDrag;
        }
        else
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.drag = defaultDrag;
        }
    }
}
