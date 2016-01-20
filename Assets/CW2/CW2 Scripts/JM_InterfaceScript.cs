using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Character
{
    public class JM_InterfaceScript : MonoBehaviour
    {
        protected JM_LevelManager mLM_LevelManager;

        public GameObject mGO_PC;
        public JM_PCScript mMB_PCScript;

        public Image ScreenFade;
        public Text GameOver;
        public Text Score;

        public bool MenuAccess;

        public CanvasGroup MenuCanvas;
        public Animator MenuAnimator;
        public AnimationClip MenuOpen;
        public AnimationClip MenuClose;

        // Use this for initialization
        void Start()
        {
            mLM_LevelManager = GameObject.Find("LevelManager").GetComponent<JM_LevelManager>();
            Score = GameObject.Find("Score").GetComponent<Text>();
            Score.text = "Score: " + mLM_LevelManager.Score.ToString();
            mMB_PCScript = mLM_LevelManager.mGO_PC.GetComponent<JM_PCScript>();
            ScreenFade = GameObject.Find("ScreenFade").GetComponent<Image>();
            MenuCanvas = GameObject.Find("MenuUI").GetComponent<CanvasGroup>();
            MenuAnimator = MenuCanvas.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            DeathCheck();
            MenuCheck();
        }

        void DeathCheck()
        {
            if(mMB_PCScript.Dead == true)
            {
                ScreenFade.CrossFadeAlpha(255, 0.4f, false);
                MenuCanvas.alpha = 255;
            }
        }

        public void RestartGame()
        {
            mMB_PCScript.transform.position = new Vector3(0, 0, 0);//reset PC spawn point
            Application.LoadLevel(1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void MenuCheck()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(MenuAccess)
                {
                    MenuAnimator.Play(MenuOpen.name);
                    MenuCanvas.interactable = true;
                    MenuAccess = false;
                }
                if(!MenuAccess)
                {
                    MenuAnimator.Play(MenuClose.name);
                    MenuCanvas.interactable = false;
                    MenuAccess = true;
                }
            }
        }
    }
}

