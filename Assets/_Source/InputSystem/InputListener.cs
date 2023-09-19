using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKey;
        [SerializeField] private Player player;
        private PlayerInvoker _playerInvoker;
        private const string _horizontalAxis = "Horizontal";
    
        private void Awake()
        {
            _playerInvoker = new PlayerInvoker(player);
            player.gameObject.AddComponent<PlayerCollisionDetector>()
                .Initialize(_playerInvoker, player.EnemyBulletLayer);
        }
    
        private void Update()
        {
            ReadMove();
            ReadShoot();
        }
    
        private void ReadMove()
        {
            float moveHorizontal = Input.GetAxisRaw(_horizontalAxis);
            
            Vector2 moveDirection = new Vector2(moveHorizontal, 0f );
            
            _playerInvoker.Move(moveDirection);
        }
        
        private void ReadShoot()
        {
            if (Input.GetKeyDown(shootKey))
            {
                _playerInvoker.Shoot();
            }
        }
    }
}
