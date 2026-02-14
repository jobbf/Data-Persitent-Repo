using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;


#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI chosenName;
    public Text bestScoreText;
    public StoreDatas savedScore;
    public int pointsValue;

    void Awake()
    {
        savedScore.LoadBestScore();
    } 


    void Start()
    {
        savedScore = GameObject.Find("StoreDatas").GetComponent<StoreDatas>();
        bestScoreText.text = StoreDatas.Instance.bestScoreValue;
        pointsValue = StoreDatas.Instance.pointsValue;
    }


    public void StartNewGame()
    {
        StoreDatas.Instance.pointsValue = pointsValue;
        StoreDatas.Instance.bestScoreValue = bestScoreText.text;
        StoreDatas.Instance.chosenNameValue = chosenName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        savedScore.SaveBestScore();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

        #else
        Application.Quit(); // original code to quit Unity player

        #endif
    }
}
