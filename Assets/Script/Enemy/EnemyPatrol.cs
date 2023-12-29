using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {


    private float _enemySpeed = 4f;
    [SerializeField] Transform[] _patrolPointsTransform;
    private float _waitingTimeOnPoint = 4f;
    private int _currentPoint;

    private bool _once = false;

    private void Update() {

        if (transform.position != _patrolPointsTransform[_currentPoint].position) {
            //     Debug.Log("enemy trying to get to patrol point");
            transform.position = Vector3.MoveTowards(transform.position, _patrolPointsTransform[_currentPoint].position, _enemySpeed * Time.deltaTime);

        } else {
            // you reached the patrol point now wait and move to the next one.
            if (_once == false) {
                _once = true;
                //   Debug.Log("coroutine called");
                StartCoroutine(WaitOnPoint());
            }

        }


    }


    private IEnumerator WaitOnPoint() {

        yield return new WaitForSeconds(_waitingTimeOnPoint);

        if (_currentPoint + 1 < _patrolPointsTransform.Length) {
            _currentPoint++;
        } else {
            // it means you reached all the points  now reset to repeat the process
            _currentPoint = 0;
        }
        _once = false;
    }
}
