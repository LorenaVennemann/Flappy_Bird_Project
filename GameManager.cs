using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;

    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        Pause();
    }

    public void Play()
    {
        Debug.Log("Hi");
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

    }

    public void IncreaseScore()
    {
        score++;
            LoadNextScene();
        scoreText.text = score.ToString();
       
    }

    private void LoadNextScene() {
        if (score == 25)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {

            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        }
    }

}