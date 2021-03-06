﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpManager : MonoBehaviour
{
    public GameObject[] Hearts;
    public Rigidbody2D CharacterBody;
    public PixelutoController PixelutoController;
    public Animator Animator;
    public GameObject GameOverPanel;

    private int _hp;
    private int _currLvl;


    void Start ()
    {
        _hp = Hearts.Length;
        GameOverPanel.SetActive(false);
	}

    public int GetHearts()
    {
        return _hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            knockBack();
            _hp--;
            if(_hp < 0)
            {
                _hp = 0;
            }
            Hearts[_hp].SetActive(false);
        }
        if(_hp < 1)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        PixelutoController.CanMove = false;
        StartCoroutine("death");
        ValueContainer.Container.Score = 0;
    }

    public void RestartGame()
    {
        ValueContainer.Container.CurrLvl = 1;
        SceneManager.LoadScene("GameLvl" + ValueContainer.Container.CurrLvl);
    }

    public void BackToMenu()
    {
        ValueContainer.Container.CurrLvl = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void knockBack()
    {
        PixelutoController.CanMove = false;
        Vector2 vector = new Vector2(PixelutoController.Direction < 0 ? 
            Random.Range(8.0f, 12.0f) : Random.Range(-12.0f, -8.0f), Random.Range(3.0f, 10.0f));
        CharacterBody.velocity = vector;
        StartCoroutine("haltMovement");
    }

    IEnumerator haltMovement()
    {
        yield return new WaitForSeconds(0.5f);
        PixelutoController.CanMove = true;
    }

    IEnumerator death()
    {
        Animator.Play("smrt");
        yield return new WaitForSeconds(1.8f);
        Animator.speed = 0;
        GameOverPanel.SetActive(true);
    }
}
