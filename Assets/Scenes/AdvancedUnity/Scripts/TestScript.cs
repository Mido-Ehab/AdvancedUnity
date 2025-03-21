using System.Collections.Generic;
using UnityEngine;

using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MovingSphere : MonoBehaviour
{
    [SerializeField] private Transform[] _cubesTransform;
    [SerializeField] private float _moveSpeedMultiplier = 10;
    [SerializeField] private Transform _currentCube;
    [SerializeField] private Transform _targetCube;

    private Transform _previousCube;
    private Rigidbody _rigidbody;
    private Collider _colliders;
    //caching   //cache
    private List<Vector3> distances = new List<Vector3>(8);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckNearCube();
        MoveToTarget();

        //invoke
        //SendMessage
        //FindObjectOfType
        //GameObject.Find
        //gameObject.tag ==

    }


    private void FixedUpdate()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
    }
    private void MoveToTarget()
    {
        transform.position += (_targetCube.position - transform.position).normalized * Time.deltaTime * _moveSpeedMultiplier;
    }

    private void CheckNearCube()
    {
        //save minimum distance
        float minDistance = int.MaxValue;

        //check if reached target against  target cube
        if (Vector3.SqrMagnitude(transform.position - _targetCube.position) < 1)
        {
            //when reached , target cube become currentCube
            _previousCube = _currentCube;
            _currentCube = _targetCube;

            //loop for cubes
            for (int i = 0; i < _cubesTransform.Length; i++)
            {

                if (_cubesTransform[i] == _currentCube)
                    continue;

                if (_cubesTransform[i] == _previousCube)
                    continue;

                float tempDistance = Vector3.SqrMagnitude(_currentCube.position - _cubesTransform[i].position);
                //check distance between currentCube  ,  index i
                if (tempDistance < minDistance)
                {
                    minDistance = tempDistance;
                    //set new Target
                    _targetCube = _cubesTransform[i];
                }
            }

        }
    }






    //void Update()
    //{
    //    //save minimum distance
    //    float minDistance = int.MaxValue;

    //    //check if reached target against  target cube
    //    if (Vector3.Distance(transform.position, _targetCube.position) < 1)
    //    {
    //        //when reached , target cube become currentCube
    //        _previousCube = _currentCube;
    //        _currentCube = _targetCube;

    //        //loop for cubes
    //        for (int i = 0; i < _cubesTransform.Length; i++)
    //        {

    //            if (_cubesTransform[i] == _currentCube)
    //                continue;

    //            if (_cubesTransform[i] == _previousCube)
    //                continue;

    //            //check distance between currentCube  ,  index i
    //            if ((_currentCube.position - _cubesTransform[i].position).magnitude < minDistance)
    //            {
    //                minDistance = Vector3.Distance(_currentCube.position, _cubesTransform[i].position);

    //                //set new Target
    //                _targetCube = _cubesTransform[i];
    //            }
    //        }

    //    }


    //    transform.position += (_targetCube.position - transform.position).normalized * Time.deltaTime * _moveSpeedMultiplier;
    //}
}