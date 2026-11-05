using UnityEngine;

public class Alien : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject bulletPrefab;
    public AlienFleet fleet;

    public GameObject explosionPrefab;
    
    static float bulletSpawnRate = .002f;
    public float lastShot = 0;
    public static float shotCooldown = .1f;

    void Start()
    {
        lastShot = 0f; 
    }
    
    void FixedUpdate()
    {
        Vector3 position = transform.position;
        
        if(UnityEngine.Random.value < bulletSpawnRate && Time.time - lastShot > shotCooldown)
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = position;
            lastShot = Time.time;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        int otherLayer = coll.gameObject.layer;

        if (otherLayer == LayerMask.NameToLayer("Bullet")) 
        {
            // Spawn the explosion at the alien's current position
            if (explosionPrefab != null) Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            
            fleet.OnAlienDestroyed(gameObject);
            Destroy(coll.gameObject); // destroy the dart
            Destroy(gameObject);      // destroy the alien
        } 
        else if (otherLayer == LayerMask.NameToLayer("Spaceship"))
        {
            LivesManager.Instance.LoseLife();
            coll.gameObject.GetComponent<Spaceship>()?.OnHit();
        }
    }
}
