using System;
using UnityEngine;

public class Lag: MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _lagAnimatorKey;
    private float _lastLagTime;
    [SerializeField] private PlayerMover _player;

    private void Update()
    {
        if (!_animator.GetBool(_lagAnimatorKey))
        {
            if (Time.time - _lastLagTime > 5f)
            {
                _animator.SetBool(_lagAnimatorKey, true );
                _lastLagTime = Time.time;
                _player.TakeDamage(_damage);
            }
            
        }
    }

    

    private void EndLag()
    {
        _animator.SetBool(_lagAnimatorKey, false );
    }
   
}
