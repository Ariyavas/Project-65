using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    public Text uiCountcoin;
    public Text uiTextBullet;
    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void SetTextCoin(int amount)
    {
        uiCountcoin.text = amount.ToString();
    }

    public void setTextBullet(int amount)
    {
        uiTextBullet.text = amount.ToString();
    }
}
