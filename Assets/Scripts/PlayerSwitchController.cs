using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitchController : MonoBehaviour {

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AnimatorOverrideController playerOverrideController;


    private void Start() {
        VictimInteractable.VictimKilled += SwitchController;
    }

    private void SwitchController() {
        playerAnimator.runtimeAnimatorController = playerOverrideController;
    }

    private void OnDisable() {
        VictimInteractable.VictimKilled -= SwitchController;
    }
}
