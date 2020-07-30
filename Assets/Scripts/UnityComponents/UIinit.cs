using Assets.UnityComponents;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIinit : MonoBehaviour
{
    // Start is called before the first frame update
    public Text wallet;
    public Text cityHealth;
    public Text money;

    private int walletVal;
    private int cityHealthVal;

    public int WalletVal { set { walletVal = value; wallet.text = value.ToString(); } }
    public int CityHealthVal { set { cityHealthVal = value; cityHealth.text = value.ToString(); } }

    void Start()
    {
        SingleTone.ui = this;
        money.gameObject.SetActive(false);
    }

    public void NotEnoughMoney()
    {
        money.gameObject.SetActive(true);
        StartCoroutine(CallDelayedAction(setinvactive, 2f));
    }

    void setinvactive()
    {
        money.gameObject.SetActive(false);
    }

    protected static IEnumerator CallDelayedAction(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }

    protected static IEnumerator CallDelayedAction(Action action, int frames)
    {
        for (int i = 0; i < frames; i++)
        {
            yield return null;
        }

        action.Invoke();
    }
}
