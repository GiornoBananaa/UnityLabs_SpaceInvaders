using System;
using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Button restartButton;

        private GameState _gameState;
        
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
            _gameState.Restart();
        }

        public void Initialize(GameState gameState)
        {
            _gameState = gameState;
        }
    }
}