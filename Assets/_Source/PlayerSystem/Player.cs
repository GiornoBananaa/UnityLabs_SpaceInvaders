using GameSystem;
using UISystem;
using UnityEngine;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float PlayerBorderMinX { get; private set; }
        [field: SerializeField] public float PlayerBorderMaxX { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public int MaxLives { get; private set; }
        [field: SerializeField] public LayerMask EnemyBulletLayer { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public PlayerHUD PlayerHud { get; private set; }
        [field: SerializeField] public Game Game { get; private set; }
    }
}
