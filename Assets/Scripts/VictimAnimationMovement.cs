using UnityEngine;

public class VictimAnimationMovement : MonoBehaviour {

    private Vector3 previousPosition = new Vector3();
    private bool isMoving;
    private int movingDirection;
    [SerializeField] private Animator victimAnimator;
    [SerializeField] private SpriteRenderer victimSpriteRenderer;

    void Start() {

    }

    void Update() {
        CheckIfMoving();
        SetAnimatorStates();
    }

    private void LateUpdate() {
        previousPosition = transform.position;
    }

    private void CheckIfMoving() {
        if (previousPosition != transform.position) {
            isMoving = true;

            Vector3 tmpDirection = transform.position - previousPosition;
            if (tmpDirection.z > 0) {
                movingDirection = 1;
            } else if (tmpDirection.z < 0) {
                movingDirection = -1;
            }

            if (tmpDirection.x > 0) {
                victimSpriteRenderer.flipX = false;
            } else if (tmpDirection.x < 0) {
                victimSpriteRenderer.flipX = true;
            }

        } else {
            isMoving = false;
            movingDirection = 0;
        }
    }

    private void SetAnimatorStates() {
        victimAnimator.SetBool("IsMoving", isMoving);
        victimAnimator.SetInteger("MoveDirection", movingDirection);
    }
}
