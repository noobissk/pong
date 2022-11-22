using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static bool IsPaused;
    [SerializeField] GameObject PauseMenu;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            IsPaused = false;
        }
    }
    

    public void Quit()
    {
        Application.Quit();
    }
}
