using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance { get; private set;}

    [SerializeField] private TextMeshProUGUI remainText;

    [SerializeField] private GameObject button;
    [SerializeField] private TextMeshProUGUI resultText;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(instance);
        }
    }

    public void UpdateRemainGoal(int remainTime) {
        remainText.SetText(remainTime.ToString());
    }

    public void ShowButton(bool result) {
        button.SetActive(true);
        resultText.SetText(result ? "Next Stage" : "Retry");
    }
}
