using System.Collections;
using UnityEngine;

public class SpearGun : MonoBehaviour
{
    public GameObject spearPrefab;
    private float shootForce = 10f;

    public float reloadTime {  get; private set; }
    public  float reloadTimeMax { get; private set; } = 1f;



    private void Update()
    {
        reloadTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            FireSpear(mousePosition);
            
        }
    }

    private void FireSpear(Vector3 mousePosition)
    {
        if (reloadTime >= reloadTimeMax)
        {
            reloadTime = 0f;

            // Fire Shoot + Reload SFX event here

            GameObject spear = Instantiate(spearPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();

            Vector2 shootDirection = (mousePosition - transform.position).normalized;
            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);

            float targetAngle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        }
        else
        {
            return;
        }
    }
}
