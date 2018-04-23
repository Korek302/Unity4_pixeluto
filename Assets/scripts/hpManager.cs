using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class hpManager : MonoBehaviour
{
    public GameObject[] Hearts;
    public Rigidbody2D CharacterBody;
    public Platformer2DUserControl PlayerController;
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
        PlayerController.movingEnabled = false;
        Animator.speed = 0;
        GameOverPanel.SetActive(true);
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
        StartCoroutine("haltMovement");
        Vector2 vector = new Vector2(Random.Range(-10.0f, -5.0f), Random.Range(0.0f, 6.0f));
        CharacterBody.velocity = vector;
    }

    IEnumerator haltMovement()
    {
        PlayerController.movingEnabled = false;
        yield return new WaitForSeconds(0.5f);
        PlayerController.movingEnabled = true;
    }
}
