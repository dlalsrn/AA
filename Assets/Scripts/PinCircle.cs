using UnityEngine;

public class PinCircle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    private bool isPinned = false;

    private bool isLaunched = false;

    void FixedUpdate() {
        if (isPinned || !isLaunched) {
            return;
        }

        transform.position += Vector3.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("TargetCircle")) {
            isPinned = true;
            
            GameObject line = transform.Find("Line").gameObject;
            SpriteRenderer lineSpriteRenderer = line.GetComponent<SpriteRenderer>();
            lineSpriteRenderer.enabled = true;

            transform.SetParent(collider.transform);

            GameManager.instance.DecreaseRemainGoal();
        } else if (collider.CompareTag("PinCircle")) {
            isPinned = true;
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch() {
        isLaunched = true;
    }
}
