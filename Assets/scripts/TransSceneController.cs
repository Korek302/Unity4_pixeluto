using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransSceneController : MonoBehaviour
{
    public Text ScoreText;
    public GameObject[] Hearts;

    void Awake ()
    {
        ScoreText.text = "Score: " + ValueContainer.Container.Score;
        for(int i = Hearts.Length - 1; i >= ValueContainer.Container.Hearts; i--)
        {
            Hearts[i].SetActive(false);
        }
	}
}
