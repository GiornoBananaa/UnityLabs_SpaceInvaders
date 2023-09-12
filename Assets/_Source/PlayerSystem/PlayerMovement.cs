using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement
    {
        private readonly float _playerBorderMinX;
        private readonly float _playerBorderMaxX;

        public PlayerMovement(float playerBorderMinX, float playerBorderMaxX)
        {
            _playerBorderMinX = playerBorderMinX;
            _playerBorderMaxX = playerBorderMaxX;
        }
        
        public void Move(Transform transform,float speed, Vector2 moveDirection)
        {
            if (transform.position.x + moveDirection.x > _playerBorderMaxX
                || transform.position.x + moveDirection.x < _playerBorderMinX)
                return;
            Vector3 velocity = moveDirection * (speed*Time.deltaTime);
            transform.position += velocity;
        }
    }
}
