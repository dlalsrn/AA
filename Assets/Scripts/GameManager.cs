using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set;}

    private int currentLevel;
    private int remainGoal;

    private bool isGameOver; // 게임의 진행이 끝났는지
    private bool isResult; // 게임을 이겼는지, 졌는지

    [SerializeField] private Color winColor; // Goal 달성 시 배경 색
    [SerializeField] private Color failColor; // Goal 달성 실패 시 배경 색

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(instance);
        }
    }

    void Start() {
        isGameOver = false;
        currentLevel = PlayerPrefs.GetInt("Level", 1); // 현재 Level Load, 기본값은 1
        remainGoal = 10 + (currentLevel - 1);
        HUDManager.instance.UpdateRemainGoal(remainGoal);
    }

    public void DecreaseRemainGoal() {
        remainGoal--;
        HUDManager.instance.UpdateRemainGoal(remainGoal);
        if (remainGoal == 0) {
            SetGameOver(true);
        }
    }

    public int GetRemainGoal() {
        return remainGoal;
    }

    public bool GetGameOver() {
        return isGameOver;
    }

    public void SetGameOver(bool result) {
        if (isGameOver == false) {
            isGameOver = true;
            isResult = result;

            PlayerPrefs.SetInt("Level", isResult ? currentLevel + 1 : currentLevel);
            Camera.main.backgroundColor = (isResult ? winColor : failColor);

            Invoke("ShowButton", 1f);
        }
    }

    public void ClearLevel() {
        PlayerPrefs.DeleteAll();
        StartGame();
    }

    public void StartGame() {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void ShowButton() {
        HUDManager.instance.ShowButton(isResult);
    }
}
