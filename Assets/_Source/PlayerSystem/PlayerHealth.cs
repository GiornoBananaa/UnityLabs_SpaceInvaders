namespace PlayerSystem
{
    public class PlayerHealth
    {
        private int _hp;
        private int _livesCount;
    
    
        public PlayerHealth(int hp,int livesCount)
        {
            _hp = hp;
            _livesCount = livesCount;
        }
    
        public void GetDamage()
        {
            _hp--;
            if (_hp <= 0)
            {
                LoseLive();
            }
        }
    
        private void LoseLive()
        {
            _livesCount--;
            if (_livesCount == 0)
            {
                //TODO level restart
            }
        }
    }
}
