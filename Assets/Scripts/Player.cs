using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        #region PC

        if (Input.GetMouseButton(0))
        {
            Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position.x = mousPos.x;
            transform.position = position;
        }

        #endregion

        #region Android

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 position = transform.position;
                position.x = mousPos.x;
                transform.position = position;
            }
        }

        #endregion
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Debug.Log("You lose");
            gameManager.LoseGame();
        }
    }
}
