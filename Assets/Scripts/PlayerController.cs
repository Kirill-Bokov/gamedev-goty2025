using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 5f;
    void Update() {
        if (GameManager.Instance.isGameOver) return;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
