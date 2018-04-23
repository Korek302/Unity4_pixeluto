using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueContainer : MonoBehaviour
{
    public int Score;
    public int Hearts;
    public int CurrLvl;

    public static ValueContainer Container;

    private void Awake()
    {
        if(Container == null)
        {
            DontDestroyOnLoad(gameObject);
            Container = this;
        }
        else if(Container != this)
        {
            Destroy(gameObject);
        }
    }
}
