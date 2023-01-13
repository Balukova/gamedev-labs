using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    private Resolution[] rsl;
    private List<string> resolutions;
    public Dropdown resolutiondropdown;

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        resolutiondropdown.ClearOptions();
        resolutiondropdown.AddOptions(resolutions);
    }
}
