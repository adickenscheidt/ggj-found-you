using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private int xAxis;
    private int zAxis;
    [SerializeField] private float moveSpeed;

    private void Update() {
        GetMovementInput();
        MovePlayer();
    }

    private void GetMovementInput() {
        xAxis = (int)Input.GetAxisRaw("Horizontal");
        zAxis = (int)Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        Vector3 currentPosition = transform.position;
        Vector3 moveDirection = new Vector3(currentPosition.x + xAxis * moveSpeed * Time.deltaTime, currentPosition.y, currentPosition.z + zAxis * moveSpeed * Time.deltaTime);
        moveDirection.Normalize();
        transform.position = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }
}
