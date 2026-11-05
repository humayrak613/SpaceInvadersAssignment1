using UnityEngine;
using UnityEngine.InputSystem;

public class Spaceship : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject dartPrefab;

    [SerializeField] private float shotCooldown = 0.05f;
    [SerializeField] private float speed = 10f;

    [Header("Screen Bounds")]
    [SerializeField] private float minX = -15f;   // left edge the ship can reach
    [SerializeField] private float maxX = 15f;    // right edge the ship can reach

    [Header("Respawn")]
    [SerializeField] private Vector3 startPosition = new Vector3(0f, -8f, 0f);
    [SerializeField] private float invulnerableTime = 1f;
    
    public GameObject explosionPrefab;

    private float lastShot = 0f;
    private bool isInvulnerable = false;

    void Start()
    {
        lastShot = 0f;
        transform.position = startPosition;
    }
    
    void Update()
    {
        // doesn't move or shoot if out of lives
        if (LivesManager.Instance != null && LivesManager.Instance.Lives <= 0) return;

        Vector3 position = transform.position;

        if (Keyboard.current.rightArrowKey.isPressed)
            position.x += speed * Time.deltaTime;
        if (Keyboard.current.leftArrowKey.isPressed)
            position.x -= speed * Time.deltaTime;

        // clamp so the ship can't leave the screen
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;

        if (Keyboard.current.spaceKey.wasPressedThisFrame &&
            Time.time - lastShot > shotCooldown)
        {
            Instantiate(dartPrefab, position, Quaternion.identity);
            lastShot = Time.time;
        }
    }

    // Called by AlienBullet when hit.
    public void OnHit()
    {
        if (isInvulnerable) return;

        // Spawn the explosion where the ship got hit
        if (explosionPrefab != null) Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Teleport back to start so there isn't a chain hit.
        transform.position = startPosition;

        isInvulnerable = true;
        Invoke(nameof(EndInvulnerability), invulnerableTime);
    }

    void EndInvulnerability()
    {
        isInvulnerable = false;
    }

}


