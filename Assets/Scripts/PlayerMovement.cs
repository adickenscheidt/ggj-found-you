using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    private Animator playerAnimator;
    private int xAxis;
    private int zAxis;

    private void Start() {
        Initialize();
    }

    private void Initialize() {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update() {
        GetMovementInput();
        MovePlayer();
        SetMovementAnimator();
    }

    private void GetMovementInput() {
        xAxis = (int)Input.GetAxisRaw("Horizontal");
        zAxis = (int)Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer() {
        Vector3 moveDirection = new Vector3(xAxis, 0, zAxis) * moveSpeed * Time.deltaTime;
        if (moveDirection.magnitude == 0) {
            return;
        } else if (moveDirection.magnitude > 1) {
            moveDirection.Normalize();
        }
        transform.Translate(moveDirection, Space.World);
    }

    private void SetMovementAnimator() {
        playerAnimator.SetInteger("MoveDirection", zAxis);
    }
}
