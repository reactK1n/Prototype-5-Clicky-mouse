using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
	private float spawnRate = 1.0f;
	private int score;
	public bool isGameActive;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public Button restartButton;
	public GameObject titleScreen;



	public List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {

    }
	public void StartGame(int difficulty)
	{
		spawnRate /= difficulty;
		isGameActive = true;
		score = 0 ;
		StartCoroutine(SpawnTarget());
		UpdateScore(0);
		titleScreen.gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	IEnumerator SpawnTarget()
	{
		while (isGameActive)
		{
			yield return new WaitForSeconds(spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
		}
	}

	public void UpdateScore(int scoreToAdd)
	{
		score += scoreToAdd;
		scoreText.text = $"Score: {score}";
	}

	public void GameOver()
	{
		gameOverText.gameObject.SetActive(true);
		isGameActive = false;
		restartButton.gameObject.SetActive(true);
	}


	public void RestartGame()
	{
		titleScreen.gameObject.SetActive(true); 
		gameOverText.gameObject.SetActive(false);
		isGameActive = true;
		restartButton.gameObject.SetActive(false);
	}

}
