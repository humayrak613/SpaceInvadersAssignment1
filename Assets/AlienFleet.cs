using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class AlienFleet : MonoBehaviour
{
    [Header("Inscribed")]

    public GameObject alienPrefab;

    public AlienCounter alienCounter;

    public List<GameObject> aliens = new List<GameObject> { };

    float speed = .1f;
    float leftBound = -16;
    float rightBound = 16;
    float lowerBound = -4f;
    float downTime = .1f;
    bool movingDown = false;
    bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject alien = Instantiate<GameObject>(alienPrefab);
                alien.transform.position = new Vector3(2 * i - 12, 10 - 2 * j, 0);
                aliens.Add(alien);
                alien.GetComponent<Alien>().fleet = this;
            }
        }

    }

    public void OnAlienDestroyed(GameObject alien)
    {
        aliens.Remove(alien);
        alienCounter.SetCount(aliens.Count);
        speed *= 1.035f;

        // win condition
        if (aliens.Count == 0)
        {
            GameManager.Instance.EndGame(true);
        }
    }

    void FixedUpdate()
    {
        if (aliens.Count == 0) return;
        if (isGameOver) return; 

        // move all alieans + check if aliens reached lowerBound
        float left = float.PositiveInfinity;
        float right = float.NegativeInfinity;
        bool aliensReachedBottom = false;

        foreach (GameObject alien in aliens)
        {
            Vector3 position = alien.transform.position;
            if (!movingDown)
            {
                position.x += speed;
            }
            else
            {
                position.y += -Mathf.Abs(speed);
            }
            alien.transform.position = position;

            if (position.x > right) right = position.x;
            if (position.x < left)  left  = position.x;

            // any alien has reached the bottom line --> game over
            if (position.y <= lowerBound)
            {
                aliensReachedBottom = true;
            }
        }

        if (aliensReachedBottom)
        {
            GameOver();
            return;
        }

        //change alien direction
        if (speed > 0 && right >= rightBound || speed < 0 && left <= leftBound)
        {
            speed = -speed;
            movingDown = true;
            Invoke("startSidewaysMotion", downTime);
        }
    }

    void startSidewaysMotion()
    {
        movingDown = false;
    }

    void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over, the aliens have reached you!");
        
        // lose condition
        GameManager.Instance.EndGame(false);
    }

}
