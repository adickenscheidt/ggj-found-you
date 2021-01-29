using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    private Animator playerAnimator;
    private int xAxis;
    private int zAxis;

    /// <summary>
    /// Self explanatory!
    /// </summary>
    private void Start() {
        Initialize();
    }

    /// <summary>
    /// Self explanatory!
    /// </summary>
    private void Initialize() {
        playerAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// Self explanatory!
    /// </summary>
    private void Update() {
        GetMovementInput();
        MovePlayer();
        SetMovementAnimator();
    }

    /// <summary>
    /// Gets the Imput from the User.
    /// </summary>
    private void GetMovementInput() {
        xAxis = (int)Input.GetAxisRaw("Horizontal");
        zAxis = (int)Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Moves the Player according to the Input of the User.
    /// </summary>
    private void MovePlayer() {
        Vector3 moveDirection = new Vector3(xAxis, 0, zAxis) * moveSpeed * Time.deltaTime;
        if (moveDirection.magnitude == 0) {
            return;
        } else if (moveDirection.magnitude > 1) {
            moveDirection.Normalize();
        }
        transform.Translate(moveDirection, Space.World);
    }

    /// <summary>
    /// Sets the Animator Properties so the Player has the correct Animation.
    /// </summary>
    private void SetMovementAnimator() {
        playerAnimator.SetInteger("MoveDirection", zAxis);
        if (xAxis != 0 || zAxis != 0) {
            playerAnimator.SetBool("IsMoving", true);
        } else {
            playerAnimator.SetBool("IsMoving", false);
        }
    }
}
