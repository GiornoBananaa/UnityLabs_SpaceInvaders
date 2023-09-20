using UISystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private EndPanel winPanel;
        [SerializeField] private EndPanel losePanel;

        private void Awake()
        {
            winPanel.Initialize(this);
            losePanel.Initialize(this);
        }

        public void Win()
        {
            Time.timeScale = 0;
            winPanel.ActivatePanel();
        }
    
        public void Lose()
        {
            Time.timeScale = 0;
            losePanel.ActivatePanel();
        }
    
        public void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
