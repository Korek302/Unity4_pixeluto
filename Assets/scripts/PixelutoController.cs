using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelutoController : MonoBehaviour
{
    private float _maxSpeed = 8.0f;
    private float _jumpForce = 300.0f;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private int _direction = 1;
    

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    _animator.SetBool("Ground", true);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    _animator.SetBool("Ground", false);
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    _animator.SetBool("Ground", true);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    _animator.SetBool("Ground", false);
    //}

    // Use this for initialization
    void Start ()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _animator.SetBool("Ground", true);
    }

	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }
	}

    private void FixedUpdate()
    {
        //var horizontal = Input.GetAxis("Horizontal");
        
        int horizontal = 0;
        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            horizontal = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            horizontal = 0;
        }

        _rigidbody.velocity = new Vector2(_maxSpeed * horizontal, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Math.Abs(_maxSpeed * horizontal));

        if(horizontal > 0)
        {
            if (_direction == -1)
            {
                _direction = 1;
                flip();
            }
        }
        else if(horizontal < 0)
        {
            if (_direction == 1)
            {
                _direction = -1;
                flip();
            }
        }
    }

    private void flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
