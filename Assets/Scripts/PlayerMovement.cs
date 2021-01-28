using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private int xAxis;
    private int yAxis;
    [SerializeField] private float moveSpeed;

    private void Update() {
        GetMovementInput();
        MovePlayer();
    }

    private void GetMovementInput() {
        xAxis = (int)Input.GetAxisRaw("Horizontal");
        yAxis = (int)Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        Vector2 currentPosition = transform.position;
        transform.position = new Vector2(currentPosition.x + xAxis * moveSpeed * Time.deltaTime, currentPosition.y + yAxis * moveSpeed * Time.deltaTime);
    }
}
