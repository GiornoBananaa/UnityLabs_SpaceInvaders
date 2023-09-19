using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [field: SerializeField] public int Damage { get; private set; }
        [SerializeField] private float speed;
        [SerializeField] private float borderMaxY;
        [SerializeField] private float borderMinY;
        private Rigidbody2D _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            _rb.velocity = transform.up * speed;

            if (transform.position.y > borderMaxY || transform.position.y < borderMinY)
                Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
    }
}
