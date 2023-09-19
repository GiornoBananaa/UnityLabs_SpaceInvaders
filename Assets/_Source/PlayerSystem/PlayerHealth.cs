using GameSystem;
using UISystem;

namespace PlayerSystem
{
    public class PlayerHealth
    {
        private readonly PlayerHUD _playerHUD;
        private readonly GameState _gameState;
        private int _hp;
        private int _livesCount;
        private int _hpMax;
        private int _livesCountMax;
    
        public PlayerHealth(int hp,int livesCount, PlayerHUD playerHUD, GameState gameState)
        {
            _hp = hp;
            _hpMax = hp;
            _livesCount = livesCount;
            _livesCountMax = livesCount;
            _playerHUD = playerHUD;
            _gameState = gameState;
            UpdateHealthHUD();
        }
    
        public void GetDamage()
        {
            _hp--;
            
            if (_hp <= 0)
            {
                LoseLive();
            }
            
            UpdateHealthHUD();
        }
    
        private void LoseLive()
        {
            _livesCount--;
            
            if (_livesCount == 0)
            {
                _gameState.Lose();
            }
            else
            {
                
                _hp = _hpMax;
            }
        }

        private void UpdateHealthHUD()
        {
            _playerHUD.UpdateHealthHUD( _hp, _livesCount);
        }
    }
}
