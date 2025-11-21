using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float forwardSpeed = 5f;     
    public float sideSpeed = 5f;        
    public float sideLimit = 3f;        

    void Update() {
        if (GameManager.Instance.isGameOver) return;

        transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);

        float inputX = Input.GetAxis("Horizontal");  // A/D или стрелки

        Vector3 move = Vector3.forward * inputX * sideSpeed * Time.deltaTime;
        transform.Translate(move);

        Vector3 pos = transform.position;
        pos.z = Mathf.Clamp(pos.z, -sideLimit, sideLimit);
        transform.position = pos;
    }
}
