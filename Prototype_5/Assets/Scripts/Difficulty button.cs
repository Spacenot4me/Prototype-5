using UnityEngine;
using UnityEngine.UI;

public class Difficultybutton : MonoBehaviour
{
    private Button button;
    public int difficultyScaler;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(StartGameWithDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGameWithDifficulty()
    {
        gameManager.StartGame(difficultyScaler);
    }
}
