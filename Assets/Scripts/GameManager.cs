using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float maxXSpawn;
    [SerializeField]
    private float minXSpawn;
    [SerializeField]
    private GameObject lightningPrefab;

    [HideInInspector]
    public int score;

    [SerializeField]
    private GameObject losePanel;
    [HideInInspector]
    public bool isGameFinish;

    private void Start()
    {
        isGameFinish = false;
        score = 0;
        losePanel.SetActive(false);

        StartCoroutine(SpawnLightning());
    }

    public void LoseGame()
    {
        AudioManager.instance.Play("Lose");
        isGameFinish = true;
        losePanel.SetActive(true);
    }

    private IEnumerator SpawnLightning()
    {
        if (!isGameFinish)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(maxXSpawn, minXSpawn), 8, 0);
            Instantiate(lightningPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(1.5f);

            StartCoroutine(SpawnLightning());
        }
    }

    public void AddScore()
    {
        score++;

        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
    }
}
