using UnityEngine;

public class LookAtTouchPosition : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTurret;

    void FixedUpdate()
    {
#if ANDROID_BUILD
        if(Input.touchCount > 0) {
            _touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 direction  = Camera.main.ScreenToWorldPoint (_touchPosition) - _playerTurret.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if(angle >= 65f || angle <= -65f) return;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _playerTurret.rotation = rotation;
        }
#endif
#if UNITY_EDITOR
        Vector2 direction  = Camera.main.ScreenToWorldPoint (Input.mousePosition) - _playerTurret.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(angle >= 65f || angle <= -65f) return;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _playerTurret.rotation = rotation;

#endif
    }
}
