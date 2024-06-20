using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Expect")]
    public Canvas ExpectationCanvas;
    public TMP_InputField expectRed, expectBlue;

    [Header("Playing")]
    public Canvas PlayingCanvas;
    public TextMeshProUGUI resultRed, resultBlue, playerExpectRed, playerExpectBlue;

    [Header("Result")]
    public Canvas ResultCanvas;
    public TextMeshProUGUI winningTeam, score_ExpectRed, score_ExpectBlue, score_ResultRed, score_ResultBlue, total_Red, total_Blue, totalScore;

    public void SetExpectation()
    {
        int red, blue;
        if(expectRed.text == "") red = 0;
        else red = int.Parse(this.expectRed.text);
        if (expectBlue.text == "") blue = 0;
        else blue = int.Parse(this.expectBlue.text);

        GameManager.Instance.Expect(red, blue);
        playerExpectRed.text = $"Red: {red}";
        playerExpectBlue.text = $"Blue: {blue}";
    }

    public void UpdateScore()
    {
        resultRed.text = $"Red: {GameManager.Instance.resultRed}";
        resultBlue.text = $"Red: {GameManager.Instance.resultBlue}";
    }

    public void SetResult()
    {
        if(GameManager.Instance.winningTeam == Team.Red)
        {
            winningTeam.text = "Red Team Win!";
            winningTeam.color = Color.red;
        }
        else
        {
            winningTeam.text = "Blue Team Win!";
            winningTeam.color = Color.blue;
        }

        score_ExpectRed.text = GameManager.Instance.expectRed.ToString();
        score_ExpectBlue.text = GameManager.Instance.expectBlue.ToString();
        score_ResultRed.text = GameManager.Instance.resultRed.ToString();
        score_ResultBlue.text = GameManager.Instance.resultBlue.ToString();
        total_Red.text = GameManager.Instance.redScore.ToString();
        total_Blue.text = GameManager.Instance.blueScore.ToString();
        totalScore.text = GameManager.Instance.totalScore.ToString();
    }

    public void ButtonSound()
    {
        SoundManager.Instance.PlaySound("Click");
    }

    public UIManager()
    {
        Instance = this;
    }
}