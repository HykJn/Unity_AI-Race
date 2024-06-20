using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Team
{
    Red, Blue
}

public class GameManager : MonoBehaviour
{
    public enum PlayingState
    {
        Expectation, Playing, Result
    }

    public static GameManager Instance;
    public PlayingState state
    {
        set
        {
            switch(value)
            { 
                case PlayingState.Expectation:
                    UIManager.Instance.ExpectationCanvas.enabled = true;
                    UIManager.Instance.PlayingCanvas.enabled = false;
                    UIManager.Instance.ResultCanvas.enabled = false;
                    break;
                case PlayingState.Playing:
                    UIManager.Instance.ExpectationCanvas.enabled = false;
                    UIManager.Instance.PlayingCanvas.enabled = true;
                    UIManager.Instance.ResultCanvas.enabled = false;
                    break;
                case PlayingState.Result:
                    GetScore();
                    UIManager.Instance.SetResult();
                    UIManager.Instance.ExpectationCanvas.enabled = false;
                    UIManager.Instance.PlayingCanvas.enabled = false;
                    UIManager.Instance.ResultCanvas.enabled = true;
                    break;
            }
        }
    }
    public Team winningTeam
    {
        get
        {
            if (resultRed == 5) return Team.Red;
            else return Team.Blue;
        }
    }
    public int expectRed, expectBlue, resultRed, resultBlue, redScore, blueScore, totalScore;

    private void Awake()
    {
        state = PlayingState.Expectation;
    }

    private void Update()
    {
        if(resultRed == 5 || resultBlue == 5)
        {
            state = PlayingState.Result;
            Time.timeScale = 0;
        }
    }

    public void Init()
    {
        Time.timeScale = 1;
        expectRed = 0;
        expectBlue = 0;
        resultRed = 0;
        resultBlue = 0;
        redScore = 0;
        blueScore = 0;
        totalScore = 0;
        state = PlayingState.Expectation;
        SceneManager.LoadScene("AI-Race");
    }

    public void Expect(int red, int blue)
    {
        expectRed = red;
        expectBlue = blue;
    }

    public void Play()
    {
        state = PlayingState.Playing;
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
        foreach (GameObject agent in agents)
        {
            agent.GetComponent<AgentController>().Move();
        }
    }

    public void GetScore()
    {
        int distance = Mathf.Abs(resultRed - expectRed);
        redScore = (5 - distance) * 20;

        distance = Mathf.Abs(resultBlue - expectBlue);
        blueScore = (5 - distance) * 20;

        if (expectRed == 5 && resultRed == 5) redScore = 400;
        else if (expectBlue == 5 && resultBlue == 5) blueScore = 400;

        totalScore = redScore + blueScore;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public GameManager()
    {
        Instance = this;
    }
}