using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager gameManager;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
            gameManager.AddScore();
        }
    }
}
