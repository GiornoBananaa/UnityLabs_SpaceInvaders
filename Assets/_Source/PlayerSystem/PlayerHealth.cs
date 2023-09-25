using GameSystem;
using UISystem;

namespace PlayerSystem
{
    public class PlayerHealth
    {
        private readonly PlayerHUD _playerHUD;
        private readonly Game _game;
        private int _hp;
        private int _livesCount;
        private int _hpMax;
        private int _livesCountMax;
    
        public PlayerHealth(int hp,int livesCount, PlayerHUD playerHUD, Game game)
        {
            _hp = hp;
            _hpMax = hp;
            _livesCountMax = livesCount;
            _livesCount = _livesCountMax;
            _playerHUD = playerHUD;
            _game = game;
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
                _game.Lose();
            }
            else
            {
                
                _hp = _hpMax;
            }
        }

        private void UpdateHealthHUD()
        {
            _playerHUD.UpdateHealthHUD( _hp,_hpMax, _livesCount);
        }
    }
}
