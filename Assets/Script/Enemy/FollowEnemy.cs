using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour {

    private Transform _target;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float minimumDistance = 2f;
    [SerializeField] private GameObject _projectile;


    private float projectileTimer;
    private float projectileTimerDelay = 1f;


    public enum EnemyState {
        EnemyFollowPlayer,
        EnemyRetreat,

    }
    public EnemyState state;

    private void Start() {
        _target = GameObject.FindObjectOfType<Player>().transform;
    }


    private void Update() {


        // Attack
        if (projectileTimer < Time.time) {
            Instantiate(_projectile, transform.position, Quaternion.identity);
            projectileTimer = Time.time + projectileTimerDelay;
        }

        switch (state) {
            case EnemyState.EnemyFollowPlayer:


                if (Vector3.Distance(transform.position, _target.position) > minimumDistance) {


                    transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);


                } else {



                }

                break;
            case EnemyState.EnemyRetreat:

                if (Vector3.Distance(transform.position, _target.position) < minimumDistance) {


                    transform.position = Vector3.MoveTowards(transform.position, _target.position, -_speed * Time.deltaTime);

                }


                break;
        }

        RotateEnemy();


    }



    private void RotateEnemy() {


        Vector3 relativePos = _target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime * _speed);

    }


}
