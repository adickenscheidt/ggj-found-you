using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed;

    private void Update() {
        MovePlayer();
    }

    private void MovePlayer() {
        Vector3 moveDirection = new Vector3((int)Input.GetAxisRaw("Horizontal"), 0, (int)Input.GetAxisRaw("Vertical")) * moveSpeed * Time.deltaTime;
        if (moveDirection.magnitude == 0) {
            return;
        } else if (moveDirection.magnitude > 1) {
            moveDirection.Normalize();
        }
        transform.Translate(moveDirection, Space.World);
    }
}
