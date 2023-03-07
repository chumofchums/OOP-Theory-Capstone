using System.Collections;
using UnityEngine;

public class SpearGun : MonoBehaviour
{
    public GameObject spearPrefab;
    public float shootForce = 10f;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            GameObject spear = Instantiate(spearPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();

            Vector2 shootDirection = (mousePosition - transform.position).normalized;
            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);

            float targetAngle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        }
    }
}
