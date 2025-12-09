using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [System.Serializable]
    public struct GroundRay
    {
        public Vector2 offset;
        public float length;       
    }

    [Header("Input")]
    [SerializeField] private LayerMask _layerMask;

    [Header("Options Raycast")]
    [SerializeField] private float _rayLength = 0.2f;
    [Header("Extra Ray Settings")]
    [SerializeField] private GroundRay[] rays;


    [Header("Debug")]
    public bool DebugModus = false;


    private bool _isGrounded;
    private Vector2 _direction = Vector2.down;


    private void FixedUpdate()
    {
        _isGrounded = false;
        MainRaycast();
        if (rays.Length > 0 && _isGrounded != true)
        {
            OptionalRaycast();
        }
    }

    public bool CheckGround()
    {

        return _isGrounded;
    }

    private void MainRaycast()
    {
        Vector2 _rayStart = (Vector2)transform.position;

        RaycastHit2D hit = Physics2D.Raycast(_rayStart, _direction, _rayLength, _layerMask);

        if (hit.collider != null)
        {
            _isGrounded = true;
        }       

        if (DebugModus)
        {
            Debug.DrawRay(_rayStart, _direction * _rayLength, hit.collider!=null ? Color.green : Color.red);
        }

    }

    private void OptionalRaycast()
    {
        for (int i = 0; i < rays.Length; i++)
        {
            Vector2 rayStart = (Vector2)transform.position + rays[i].offset;
            RaycastHit2D hit = Physics2D.Raycast(rayStart, _direction, rays[i].length, _layerMask);
            if (DebugModus)
            {
                Debug.DrawRay(rayStart, _direction * rays[i].length,hit.collider!=null ? Color.green : Color.red);
            }
            if (hit.collider != null)
            {
               _isGrounded = true;
                break;
            }          
        }
    }
}
