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
        Vector3 moveDirection = new Vector3(xAxis, 0, zAxis);
        moveDirection.Normalize();
        transform.position = new Vector3(currentPosition.x + moveDirection.x * moveSpeed * Time.deltaTime, currentPosition.y + moveDirection.y * moveSpeed * Time.deltaTime, currentPosition.z + moveDirection.z * moveSpeed * Time.deltaTime);
    }
}
