using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WatchingEnemy : MonoBehaviour {

    private float _rotationSpeed = 35f;

    private float _visionDistance = 5f;

    [SerializeField] private LayerMask _layers;

    [SerializeField] private LineRenderer _lineOfSights;

    private void Update() {


        _lineOfSights.SetPosition(0, transform.position);

        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);

        //  transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed);



        //      RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.forward, _visionDistance);


        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, _visionDistance, _layers)) {

            if (raycastHit.collider != null) {

                Debug.Log(" i hit something");

                Debug.DrawLine(transform.position, raycastHit.point, Color.red, 1f);

                _lineOfSights.SetPosition(1, raycastHit.point);
                _lineOfSights.transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
                _lineOfSights.startColor = Color.red;
                _lineOfSights.endColor = Color.red;


            }

        } else {
            Debug.Log(" i didn't hit anything");

            Debug.DrawLine(transform.position, transform.position + transform.forward * _visionDistance, Color.green, 1f);

            _lineOfSights.SetPosition(1, transform.position + transform.forward * _visionDistance);
            _lineOfSights.transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
            _lineOfSights.startColor = Color.green;
            _lineOfSights.startColor = Color.green;
        }

    }
}





