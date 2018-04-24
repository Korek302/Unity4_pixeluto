using System;
using System.Collections;
using UnityEngine;

public class PixelutoController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public bool CanMove = true;
    public GameObject Bullet;
    public int Direction = 1;
    
    [SerializeField]
    private AudioClip szczekankoClip;
    [SerializeField]
    private AudioClip pantingClip;

    private float _maxSpeed = 8.0f;
    private float _jumpForce = 2000.0f;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isOnGround;
    private float _groundRadius = 0.3f;
    private AudioSource _audioSource;

    void Start ()
    {
        _animator = this.GetComponent<Animator>();
        _rigidbody = this.GetComponent<Rigidbody2D>();
        _audioSource = this.GetComponent<AudioSource>();
    }
    
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space) && _isOnGround && CanMove)
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce));
        }

        int horizontal = 0;

        if (Input.GetKey(KeyCode.D) && CanMove)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = pantingClip;
                _audioSource.PlayOneShot(pantingClip);
            }
            horizontal = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            horizontal = 0;
            _audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.A) && CanMove)
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.clip = pantingClip;
                _audioSource.PlayOneShot(pantingClip);
            }
            horizontal = -1;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            horizontal = 0;
            _audioSource.Stop();
        }

        if (CanMove)
        {
            _rigidbody.velocity = new Vector2(_maxSpeed * horizontal, _rigidbody.velocity.y);
            _animator.SetFloat("Speed", Math.Abs(_maxSpeed * horizontal));
        }

        if(horizontal > 0)
        {
            if (Direction == -1)
            {
                Direction = 1;
                flip();
            }
        }
        else if(horizontal < 0)
        {
            if (Direction == 1)
            {
                Direction = -1;
                flip();
            }
        }

        if(Input.GetKeyDown(KeyCode.F) && CanMove && horizontal == 0)
        {
            StartCoroutine("szczekanko");
        }

        if (Input.GetKeyDown(KeyCode.E) && CanMove)
        {
            Fire();
        }

        _isOnGround = Physics2D.OverlapCircle(groundCheck.position, _groundRadius, whatIsGround);
        _animator.SetBool("Ground", _isOnGround);
	}

    private void flip()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator szczekanko()
    {
        CanMove = false;
        _animator.SetBool("Szczekanko", true);
        yield return new WaitForSeconds(1.1f);
        _audioSource.clip = szczekankoClip;
        _audioSource.PlayOneShot(szczekankoClip);
        yield return new WaitForSeconds(0.9f);
        _animator.SetBool("Szczekanko", false);
        CanMove = true;
    }

    private void Fire()
    {
        Transform t = gameObject.transform;
        if (Direction > 0)
        {
            var bullet = (GameObject)Instantiate(Bullet, new Vector3(t.position.x + 1.0f, t.position.y, t.position.z), t.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(20.0f, 0.0f);
            Destroy(bullet, 5.0f);
        }
        else
        {
            var bullet = (GameObject)Instantiate(Bullet, new Vector3(t.position.x - 1.0f, t.position.y, t.position.z), t.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-20.0f, 0.0f);
            Vector2 theScale = bullet.transform.localScale;
            theScale.x *= -1;
            bullet.transform.localScale = theScale;
            Destroy(bullet, 5.0f);
        }
    }
}
