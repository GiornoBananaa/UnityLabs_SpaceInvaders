using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Button restartButton;

        private Game _game;
        
        private void Start()
        {
            restartButton.onClick.AddListener(RestartButton);
        }

        public void ActivatePanel()
        {
            panel.SetActive(true);
        }
        
        public void RestartButton()
        {
            _game.Restart();
        }

        public void Initialize(Game game)
        {
            _game = game;
        }
    }
}