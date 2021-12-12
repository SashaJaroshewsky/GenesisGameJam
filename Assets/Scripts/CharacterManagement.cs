using System;
using UnityEngine;

public class CharacterManagement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jampForce;
    
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;

    [SerializeField] private bool _faceRight;
    
    private float _horizontalDirection;
    private float _verticalDirection;

    private bool _jump;
        
    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
        }
        
        if (_horizontalDirection > 0 && !_faceRight)
        {
            Flip();
        }
        else if(_horizontalDirection < 0 && _faceRight)
        {
            Flip();
        }
    }
    
    private void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0,180, 0);
    }

    private void FixedUpdate()
    {
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);

        _rigidbody.velocity = new Vector2( _horizontalDirection * _speed, _rigidbody.velocity.y);
        if (_jump && canJump)
        {
            _rigidbody.AddForce(Vector2.up * _jampForce);
            _jump = false;
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
        Gizmos.color = Color.blue;
    }
}