using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Camera _camera;

    [SerializeField] float moveSpeed = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        InputManager.PlayerMovementEvent += MoveCharacter;
    }

    private void OnDestroy()
    {
        InputManager.PlayerMovementEvent -= MoveCharacter;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void FixedUpdate()
    {

    }

    private void MoveCharacter(Vector2 direction)
    {
        _rb.MovePosition(_rb.position + (direction * moveSpeed * Time.fixedDeltaTime));       
    }

    private void HandleRotation()
    {
        Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x);
        float angle = angleRad * Mathf.Rad2Deg;      
        _rb.rotation = angle;
    }


}
