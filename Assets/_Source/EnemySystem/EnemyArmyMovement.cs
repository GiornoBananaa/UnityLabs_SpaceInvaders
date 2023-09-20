using UnityEngine;

namespace EnemySystem
{
    public class EnemyArmyMovement
    {
        private Transform _transform;
        private float _step;
        private float _xMaxSteps;
        private float _yMaxSteps;//TODO переместить в enemy collision
        private float _yMoveBeforeRotation;
        private float _xCenterOfPath;
        private float _timeBeforeStep;
        private MoveDirection _prevDirection;
        private MoveDirection _direction;
        
        
        private enum MoveDirection
        {
            Down, Right, Left
        }
        
        public EnemyArmyMovement(Transform transform, float step, 
             float xMaxSteps,float yMoveBeforeRotation, float xCenterOfPath)
        {
            _transform = transform;
            _step = step;
            _xMaxSteps = xMaxSteps;
            _yMoveBeforeRotation = yMoveBeforeRotation;
            _yMaxSteps = _yMoveBeforeRotation;
            _xCenterOfPath = xCenterOfPath;
            _direction = MoveDirection.Right;
            _prevDirection = _direction;
        }
        
        public void Move()
        {
            //TODO шагающее движение
            _timeBeforeStep -= Time.deltaTime;
            
            switch (_direction)
            {
                case MoveDirection.Down:
                    _transform.position += Vector3.down * _step;
                    _yMaxSteps -= _step * Time.deltaTime;
                    if (_yMaxSteps <= 0)
                    {
                        _yMaxSteps = _yMoveBeforeRotation;
                        _direction = _prevDirection == MoveDirection.Right ? 
                            MoveDirection.Left : MoveDirection.Right;
                        _prevDirection = MoveDirection.Down;
                    }
                    break;
                case MoveDirection.Right:
                    _transform.position += Vector3.right * _step;
                    
                    if (_transform.position.x - _xCenterOfPath > _xMaxSteps)
                    {
                        _prevDirection = _direction;
                        _direction = MoveDirection.Down;
                    }
                    break;
                case MoveDirection.Left:
                    _transform.position += Vector3.left * _step;
                    
                    if (_transform.position.x - _xCenterOfPath < -_xMaxSteps)
                    {
                        _prevDirection = _direction;
                        _direction = MoveDirection.Down;
                    }
                    break;
            }
        }
    }
}