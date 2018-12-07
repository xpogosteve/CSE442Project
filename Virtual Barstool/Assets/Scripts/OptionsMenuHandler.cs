using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem
{
    public class OptionsMenuHandler : MonoBehaviour
    {
        public string gameSceneLocation;
        public Text txt;
        public string menuSceneLocation;
        private int vol = 100;
        

        public void Start()
        {
            txt.text = vol.ToString();
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        public void StartGame()
        {
            SceneManager.LoadScene(gameSceneLocation);
        }
        public void VolumeUp()
        {
            if (vol < 100)
            {
                vol+=10;
                txt.text = vol.ToString();
                AudioListener.volume = vol;
            } 
        }
        public void VolumeDown()
        {
            if (vol > 0)
            {
                vol-=10;
                txt.text = vol.ToString();
                AudioListener.volume = vol;
            }
        }
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(menuSceneLocation);
        }
        public void Pause ()
        {
            Time.timeScale = 0;
        }
        public void Resume ()
        {
            Time.timeScale = 1;
        }
    }
}
