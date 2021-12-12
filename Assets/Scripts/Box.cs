using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Transform _pointPosition;
    [SerializeField] private GameObject _boxPoint;
    [SerializeField] private Collider2D _boxColider;
   
    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerMover player = other.GetComponent<PlayerMover>();
       
    }
}
