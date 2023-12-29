using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {


    private Vector3 _target;
    private float _projectileSpeed = 3f;


    private void Start() {
        _target = GameObject.FindAnyObjectByType<Player>().transform.position;
    }


    private void Update() {



        transform.position = Vector3.MoveTowards(transform.position, _target, _projectileSpeed * Time.deltaTime);


        if (transform.position == _target) {

            Destroy(gameObject);

        }

    }



}
