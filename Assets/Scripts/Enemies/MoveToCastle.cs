using UnityEngine;

public class MoveToCastle : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Rigidbody2D _enemyRigidbody;

    private void FixedUpdate() {
        _enemyRigidbody.velocity = new Vector2(-1 * _speed, 0);
    }
}
