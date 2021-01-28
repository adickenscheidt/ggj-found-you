using UnityEngine;

public class RotateToCamera : MonoBehaviour {
    void Update() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Camera.main.transform.rotation, 100f);
    }
}
