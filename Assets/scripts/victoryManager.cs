using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class VictoryManager : MonoBehaviour
{
    public GameObject PlayAgainButton;
    public GameObject LvlFinishPanel;
    public GameObject VictoryPanel;
    public GameObject Player;
    public Animator Animator;
    private const int finalLvl = 2;

    private void Start()
    {
        LvlFinishPanel.SetActive(false);
        VictoryPanel.SetActive(false);
        PlayAgainButton.GetComponent<Button>().onClick.AddListener
        (
            () => { RestartGame(); }
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player.GetComponent<PixelutoController>().CanMove = false;
            Animator.speed = 0;

            if (ValueContainer.Container.CurrLvl == finalLvl)
            {
                VictoryPanel.SetActive(true);
            }
            else
            {
                LvlFinishPanel.SetActive(true);
                StartCoroutine("jumpToNewLayer");
            }
        }
    }

    public void RestartGame()
    {
        ValueContainer.Container.CurrLvl = 1;
        ValueContainer.Container.Score = 0;
        SceneManager.LoadScene("GameLvl" + ValueContainer.Container.CurrLvl);
    }

    public void BackToMenu()
    {
        ValueContainer.Container.CurrLvl = 1;
        ValueContainer.Container.Score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator jumpToNewLayer()
    {
        yield return new WaitForSeconds(2.0f);
        ValueContainer.Container.CurrLvl++;
        ValueContainer.Container.Hearts = Player.GetComponent<HpManager>().GetHearts();
        SceneManager.LoadScene("GameLvl" + ValueContainer.Container.CurrLvl);
    }
}
