using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Thief : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal"; 
    private const string AxisVertical = "Vertical";

    [SerializeField] private float _speedMove;
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float vertical = Input.GetAxis(AxisVertical);
        transform.Translate(new Vector3(0f, 0f, vertical) * _speedMove * Time.deltaTime);
    }

    private void Rotate()
    {
        float horizontal = Input.GetAxis(AxisHorizontal);
        transform.Rotate(new Vector3(0f, horizontal, 0f) * _speedRotate * Time.deltaTime, Space.World);
    }
}
