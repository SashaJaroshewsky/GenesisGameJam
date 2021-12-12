using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = System.Object;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameObject _flora;
    [SerializeField] private GameObject _flora2;
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;

   [SerializeField] private bool _firstDimention;
    
    
    
    [Header("UI")]
    [SerializeField] private int _maxHp;
    private int _currentHp;

    [SerializeField] private Slider _hpBar;

    [SerializeField] private Transform _boxPoint;
    [SerializeField] private LayerMask _whatIsBox;
    [SerializeField] private GameObject _box;
    private Collider2D _activeBox;
   // [SerializeField] private List<GameObject> _elementsToFirstMap = new List<GameObject>();
   // [SerializeField] private List<GameObject> _elementsToLastMap = new List<GameObject>();
    private int CurrentHp
    {
        get => _currentHp;
        set
        {
            if (value > _maxHp)
                value = _maxHp;
            _currentHp = value;
            _hpBar.value = value;

        }
    }

    private void Start()
    {
        _hpBar.maxValue = _maxHp;
        CurrentHp = _maxHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            _flora.SetActive(_firstDimention);
            _flora2.SetActive(!_firstDimention);
            
            _player1.SetActive(_firstDimention);
            _player2.SetActive(!_firstDimention);
           
            _box.SetActive(!_box.activeInHierarchy);
            if (_activeBox != null)
            {
                _activeBox.gameObject.SetActive(true);
            }
            
            _firstDimention = !_firstDimention;
        }
        if ( Input.GetKeyDown(KeyCode.E))
        {
            Collider2D col = Physics2D.OverlapPoint(_boxPoint.position, _whatIsBox);
            if (col != _activeBox)
            {
                _activeBox = col;
            }
            else
            {
                _activeBox = null;
            }
        }

        if (_activeBox != null)
        {
            _activeBox.transform.position = _boxPoint.position;
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        if (_currentHp <= 0)
        {
            gameObject.SetActive(false);
            Invoke(nameof(ReloadScene), 1f);
        }
    }
    public void AddHp(int hpPoints)
    {
        int missingHp = _maxHp - CurrentHp;
        int pointToAdd = missingHp > hpPoints ? hpPoints : missingHp;
        StartCoroutine(RestoreHp(pointToAdd));
    }
    
    private IEnumerator RestoreHp(int pointToAdd)
    {
        
        while (pointToAdd != 0 )
        {
            pointToAdd--;
            CurrentHp++;
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
