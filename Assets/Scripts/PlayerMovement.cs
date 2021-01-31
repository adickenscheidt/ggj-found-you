using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    private Animator playerAnimator;
    private int xAxis;
    private int zAxis;

    [SerializeField]
    float speed;
    Rigidbody rb;


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
        rb = GetComponent<Rigidbody>();
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
        /*
        Vector3 moveDirection = new Vector3(xAxis, 0, zAxis);
        if (moveDirection.magnitude == 0) {
            return;
        } else if (moveDirection.magnitude > 1) {
            moveDirection.Normalize();
        }
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        */
        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);

        Vector2 velocity = (xMov + zMov).normalized * speed * Time.deltaTime;

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.y);
    }

    /// <summary>
    /// Sets the Animator Properties so the Player has the correct Animation.
    /// </summary>
    private void SetMovementAnimator() {
        if (Time.timeScale != 0) {
            playerAnimator.SetInteger("MoveDirection", zAxis);
            if (xAxis != 0 || zAxis != 0) {
                playerAnimator.SetBool("IsMoving", true);
            } else {
                playerAnimator.SetBool("IsMoving", false);
            }
        }
    }
}
