using System;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyArmyMovement
    {
        private enum MoveDirection
        {
            Down, Right, Left
        }
        
        private Transform _transform;
        private float _speed;
        private float _maxXStep;
        private float _yMoveBeforeRotation;
        private float _yMove;
        private float _xCenterOfPath;
        private MoveDirection _prevDirection;
        private MoveDirection _direction;
        
        public EnemyArmyMovement(Transform transform, float speed, 
             float maxXStep,float yMoveBeforeRotation, float xCenterOfPath)
        {
            _transform = transform;
            _speed = speed;
            _maxXStep = maxXStep;
            _yMoveBeforeRotation = yMoveBeforeRotation;
            _yMove = _yMoveBeforeRotation;
            _xCenterOfPath = xCenterOfPath;
            _direction = MoveDirection.Right;
            _prevDirection = _direction;
        }
        
        public void Move()
        {
            switch (_direction)
            {
                case MoveDirection.Down:
                    _transform.position += Vector3.down * (_speed * Time.deltaTime);
                    _yMove -= _speed * Time.deltaTime;
                    if (_yMove <= 0)
                    {
                        _yMove = _yMoveBeforeRotation;
                        _direction = _prevDirection == MoveDirection.Right ? 
                            MoveDirection.Left : MoveDirection.Right;
                        _prevDirection = MoveDirection.Down;
                    }
                    break;
                case MoveDirection.Right:
                    _transform.position += Vector3.right * (_speed * Time.deltaTime);
                    
                    if (_transform.position.x - _xCenterOfPath > _maxXStep)
                    {
                        _prevDirection = _direction;
                        _direction = MoveDirection.Down;
                    }
                    break;
                case MoveDirection.Left:
                    _transform.position += Vector3.left * (_speed * Time.deltaTime);
                    
                    if (_transform.position.x - _xCenterOfPath < -_maxXStep)
                    {
                        _prevDirection = _direction;
                        _direction = MoveDirection.Down;
                    }
                    break;
            }
        }
    }
}