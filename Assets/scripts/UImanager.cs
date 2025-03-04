using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    [Header("Game over")]
    [SerializeField] private GameObject gameoverscreen;

    [Header("traget chest")]
    [SerializeField] private TextMeshProUGUI targetchest;
    //[SerializeField] private GameObject chest1;
    [SerializeField] public float currentchest;
    [SerializeField] private float TargetChest = 3;

    [Header("PauseGame")]
    [SerializeField] private GameObject gamepausescreen;

    [Header("WinGame")]
    [SerializeField] private GameObject youwinscreen;
    [SerializeField] private TextMeshProUGUI score;
    private float Score;

    [Header("traget hero")]
    [SerializeField] private TextMeshProUGUI targethero;
    public int currenthero = 0;
    private int Targethero = 15;

    [Header("Tips menu")]
    [SerializeField] private GameObject tipsJumpscreen;
    [SerializeField] private GameObject tipsladdlescreen;


    private void Awake()
    {
        gameoverscreen.SetActive(false);
        gamepausescreen.SetActive(false);
        youwinscreen.SetActive(false);
        tipsJumpscreen.SetActive(false);
        tipsladdlescreen.SetActive(false);

        currenthero = Targethero;
        currentchest = TargetChest;
    }

    public void setchest()
    {
        currentchest -= 1;
        targetchest.text = currentchest + " / " + TargetChest;
    }
    public void SetEnemy()
    {
        currenthero -= 1;
        targethero.text = currenthero + " / " + Targethero;
        
    }
    public void SetScore()
    {
        float Score = TargetChest - currentchest;

        score.text = Score + " / " + TargetChest;
        print(currentchest);
    }
    public void ScoreChest()
    {
        currentchest--;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        gamepausescreen.SetActive(true);
    }
    public void ResumeGame()
    {
        gamepausescreen.SetActive(false);
        Time.timeScale = 1;
    }
    public void Gamecomplete()
    {
        Time.timeScale = 0;
        youwinscreen.SetActive(true);
    }
    public void GameOver()
    {
        gameoverscreen.SetActive(true);
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("InLand", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void jumpTips()
    {
        Time.timeScale = 0;
        tipsJumpscreen.SetActive(true);
    }
    public void laddletips()
    {
        Time.timeScale = 0;
        tipsladdlescreen.SetActive(true);
    }
    public void Escape_tips()
    {
        gamepausescreen.SetActive(false);
        tipsJumpscreen.SetActive(false);
        tipsladdlescreen.SetActive(false);
        Time.timeScale = 1;

    }
}
