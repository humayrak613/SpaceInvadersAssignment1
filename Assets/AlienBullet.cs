using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    [Header("Inscribed")]

    static float speed = .1f;

    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.y -= speed;
        transform.position = position;
        if(position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        // Only damage the ship. Darts and other aliens pass through.
        if (coll.gameObject.layer == LayerMask.NameToLayer("Spaceship"))
        {
            LivesManager.Instance.LoseLife();
            coll.gameObject.GetComponent<Spaceship>()?.OnHit();
        }

        Destroy(gameObject);
    }
}
