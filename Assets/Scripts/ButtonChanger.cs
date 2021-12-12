using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ButtonChanger : MonoBehaviour
{
    [SerializeField] private Sprite _openedDoor;
    [SerializeField] private SpriteRenderer _closedDoor;
    [SerializeField] private Collider2D _closedDoorCollider;



    [SerializeField] private Sprite _activeSprite;
    private SpriteRenderer _spriteRenderer;
    private Sprite _inactiveSprite;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inactiveSprite = _spriteRenderer.sprite;
    }

    public void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Box box = collision.GetComponent<Box>();
        if (box != null)
        {
            _spriteRenderer.sprite = _activeSprite;
            _closedDoor.sprite = _openedDoor;
            _closedDoorCollider.enabled = false;
        }
    }
}
