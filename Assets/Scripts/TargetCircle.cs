using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    private float moveSpeed = 120f;
    private float[] dir = {-1f, 1f}; // 회전 방향, -1은 시계, 1은 반시계
    private int dirIndex = 0;

    private float lastChangeTime = 0f; // 마지막으로 바꾼 시각
    private float changeInterval = 1f; // 방향과 속도가 고정되는 시간

    void Update() {
        if (GameManager.instance.GetGameOver()) {
            return;
        }

        transform.Rotate(new Vector3(0, 0, dir[dirIndex] * moveSpeed) * Time.deltaTime);

        if (Time.time - lastChangeTime >= changeInterval) {
            ChangeDirAndSpeed();
            lastChangeTime = Time.time;
            changeInterval = Random.Range(0.5f, 1f); // 0.5초 - 1초 랜덤한 간격 설정
        }
    }

    private void ChangeDirAndSpeed() {
        dirIndex = Random.Range(0, 2); // 반시계, 시계 2가지 중 하나를 선택
        moveSpeed = Random.Range(90f, 180f); // 돌아가는 속도
    }
}
