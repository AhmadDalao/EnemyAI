using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player Instance { get; private set; }

    [SerializeField] private GameInputManager _gameInputManager;

    private bool _isPlayerMoving = false;
    private float _rotateSpeed = 12f;

    void Start() {

        if (Instance != null) {
            Debug.Log("there is more than 1 player instance");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update() {
        HandlePlayerMovement();
    }


    private void HandlePlayerMovement() {
        Vector2 userInput = _gameInputManager.GetPlayerMovementNormalized();

        Vector3 direction = new Vector3(userInput.x, 0f, userInput.y);

        _isPlayerMoving = direction != Vector3.zero;

        if (_isPlayerMoving) {
            transform.forward = Vector3.Slerp(transform.forward, direction, _rotateSpeed * Time.deltaTime);
        }

        transform.position += direction * Time.deltaTime * 8f;
    }


    public bool GetIsPlayerMoving() {
        return _isPlayerMoving;
    }

}
