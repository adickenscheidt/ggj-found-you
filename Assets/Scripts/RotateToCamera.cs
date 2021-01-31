using UnityEngine;

public class RotateToCamera : MonoBehaviour {
    void Start() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Camera.main.transform.rotation, 100f);
    }
}
