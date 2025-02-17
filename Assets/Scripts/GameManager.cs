using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    public Text scoreText;

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start(){
        UpdateScoreText();
    }
    public void AddScore(int points){
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText(){
        if(scoreText != null){
            scoreText.text = "Score: " + score;
        }
    
    }


}
