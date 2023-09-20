using System.Collections.Generic;
using GameSystem;
using UISystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace EnemySystem
{
    public class EnemyArmy : MonoBehaviour
    {
        [Header("ArmyGeneration")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int rows;
        [SerializeField] private int columns;
        [SerializeField] private float spacing;
    
        [Space(2)]
        [Header("Movement")]
        [SerializeField] private float speed;
        [SerializeField] private float endYLine;
        [SerializeField] private float maxXStep;
        [SerializeField] private float yMoveBeforeRotation;
        [SerializeField] private float xCenterOfPath;

        [Space(2)] 
        [Header("Other")]
        [SerializeField] private PlayerHUD playerHUD;
        [FormerlySerializedAs("gameState")] [SerializeField] private Game game;
    
        private int _enemyCount;
        private bool _gameIsStopped;
        private Vector2 _offset;
        private Vector2[][] _enemyPositions;
        private EnemyArmyMovement _enemyArmyMovement;
        private Queue<Enemy>[] _enemies;
    
        private void Start()
        {
            _enemyArmyMovement = new EnemyArmyMovement(transform,
                speed,maxXStep,yMoveBeforeRotation,xCenterOfPath);
        
            GenerateArmy();

            ActivateShootingInFrontRow();
            
            _enemyCount = rows*columns;
            _gameIsStopped = false;
        }

        private void Update()
        {
            if(!_gameIsStopped)CheckHeight();
            _enemyArmyMovement.Move();
        }

        public void KillEnemy(int enemyColumn)
        {
            Enemy enemy = _enemies[enemyColumn].Dequeue();
            if (enemy is null) return;
        
            Destroy(enemy.gameObject);
            _enemyCount--;
            playerHUD.UpdateScoreHUD(rows*columns - _enemyCount);
            
            if (_enemyCount <= 0)
            {
                game.Win();
            }
            ActivateShootingInFrontRow();
        }
        
        private void ActivateShootingInFrontRow()
        {
            foreach(Queue<Enemy> enemies in _enemies)
            {
                if(enemies.Count == 0) continue;
                Enemy enemy = enemies.Peek();
                if (enemy is not null)
                {
                    enemy.ActivateShooting();
                }
            }
        }
        
        private void CheckHeight()
        {
            //TODO использовать колизию для проверки высоты
            if (transform.position.y <= endYLine)
            {
                game.Lose();
                _gameIsStopped = true;
            }
        }

        private void GenerateArmy()
        {
            
            _offset = new Vector2(spacing*columns/2f - 0.5f,spacing*rows/2f - 0.5f);
            _enemies = new Queue<Enemy>[columns];
            for(int column = 0; column < columns; column++)
            {
                _enemies[column] = new Queue<Enemy>();
                for (int row = 0; row < rows; row++)
                {
                    GameObject enemyObj = Instantiate(enemyPrefab,transform);
                    enemyObj.transform.position = new Vector2(transform.position.x + (spacing*column),
                        transform.position.y + (spacing*row)) - _offset;
                    Enemy enemy = enemyObj.GetComponent<Enemy>();
                    _enemies[column].Enqueue(enemy);
                    enemy.Initialize(this,column);
                }
            }
        }
    }
}
