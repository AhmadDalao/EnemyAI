using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _animator;
    private const string PLAYER_WALKING = "IsPlayerWalking";


    private void Start() {
        _animator = GetComponent<Animator>();
    }


    private void Update() {
        HandleAnimation();
    }


    private void HandleAnimation() {
        _animator.SetBool(PLAYER_WALKING, Player.Instance.GetIsPlayerMoving());
    }


}
