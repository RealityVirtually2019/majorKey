using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ControlScript : MonoBehaviour
{
    //private GameObject ControllerMesh;
    private GameObject _cube;
    private MLInputController _controller;
    private const float _rotationSpeed = 30.0f;
    private const float _distance = 2.0f;
    private const float _moveSpeed = 1.2f;
    private bool _enabled = false;
    private bool _bumper = false;
    private bool _isGrabbing;
    private GameObject obj;

    [SerializeField]
    GameObject tip;

    void Awake()
    {
        //ControllerMesh = GameObject.Find("Controller");
        Console.WriteLine("Hello World!");
        _cube = GameObject.Find("Cube");
        MLInput.Start();

        _controller = MLInput.GetController(MLInput.Hand.Left);
        _isGrabbing = false;
    }

    void OnDestroy()
    {

        MLInput.Stop();
    }

    void Update()
    {
        transform.position = _controller.Position;
        transform.rotation= _controller.Orientation;
        //print(_controller.Position);

        if (_isGrabbing) { 
        obj.transform.position = tip.transform.position;
            obj.transform.rotation = tip.transform.rotation;
        }
    }


    private void OnTriggerStay(Collider other)
    {
       //print(other.name);
        obj = other.gameObject;
        //print(other.gameObject.name);
        if (_controller.TriggerValue > 0.8f)
        {
            _isGrabbing = true;
        }
        else
        {
            _isGrabbing = false;
        }
    }



}
