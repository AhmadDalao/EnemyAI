using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour {

    public static GameInputManager Instance { get; private set; }

    private InputActionManager _inputActionManager;


    private void Awake() {


        if (Instance != null) {
            Debug.Log("There is more than 1 game input manager instance");
        }


        _inputActionManager = new InputActionManager();


        _inputActionManager.Player.Enable();


    }


    public Vector2 GetPlayerMovementNormalized() {
        Vector2 movement = _inputActionManager.Player.Move.ReadValue<Vector2>();
        return movement.normalized;
    }





}
