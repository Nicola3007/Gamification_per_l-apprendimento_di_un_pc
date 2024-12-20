using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class sample_scene_manager : MonoBehaviour
{
    public Button gioca;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setPlayerPrefsTo0();
        gioca.onClick.AddListener(() =>
        {
            cambiascena();
        });
    }

    void Update()
    {

    }

    public void cambiascena()
    {
        SceneManager.LoadScene("gioco_ruota");
    }

    private void setPlayerPrefsTo0()
    {
        PlayerPrefs.SetInt("0", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("4", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("3", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("5", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.Save();
    }

}
