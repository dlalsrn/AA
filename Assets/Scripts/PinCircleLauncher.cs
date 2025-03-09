using UnityEngine;

public class PinCircleLauncher : MonoBehaviour
{
    [SerializeField] private GameObject pinCirclePrefab;

    private PinCircle currentPinCircle;

    void Start() {
        PreparePinCircle();
    }

    void Update() {
        if (GameManager.instance.GetRemainGoal() == 0) { // 목표를 달성했으면 끝
            return;
        }

        if (Input.GetMouseButtonDown(0) && currentPinCircle != null && !GameManager.instance.GetGameOver()) {
            currentPinCircle.Launch();
            currentPinCircle = null;
            Invoke("PreparePinCircle", 0.1f);
        }
    }

    private void PreparePinCircle() {
        if (!GameManager.instance.GetGameOver()) {
            GameObject pinCircle = Instantiate<GameObject>(pinCirclePrefab, transform.position, Quaternion.identity);
            currentPinCircle = pinCircle.GetComponent<PinCircle>();
        }
    }
}
