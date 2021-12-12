using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeedZone : MonoBehaviour
{
   [SerializeField] private int _damage;
   private PlayerMover _player;
   private void OnTriggerEnter2D(Collider2D other)
   {
      PlayerMover player = other.GetComponent<PlayerMover>();
      if (player != null)
      {
         _player = player;
      }
      
   }
   
   private void Update()
   {
      if (_player != null)
      {
         
         _player.TakeDamage(_damage);
      }
   }
}
