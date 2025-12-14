using UnityEngine;

public class WallCheck : MonoBehaviour
{

    [Header("Debug")]
    [SerializeField] private bool DebugModus = false;
    [System.Serializable]
    public struct WallCheckData
    {
        [Header("Settings OverLapbox")]
        public Vector2 _boxSize;
        public Vector2 _boxOffset;
        public LayerMask layerMask;
    }
    [Header("Wall Checks")]
    [SerializeField] private WallCheckData[] _wallChecks;

    private bool _isTouchingWall;


    private void FixedUpdate()
    {
        _isTouchingWall = false;
        for (int i = 0; i < _wallChecks.Length; i++)
        {
            if (CheckOverlap(_wallChecks[i]))
            {
                _isTouchingWall = true;
                break;
            }
        }

    }

    public bool CheckWall()
    {
        return _isTouchingWall;
    }

    private bool CheckOverlap(WallCheckData data)
    {
        Vector2 boxPosition = (Vector2)transform.position + data._boxOffset;
        Collider2D hit = Physics2D.OverlapBox(boxPosition, data._boxSize, 0, data.layerMask);

        return hit != null;
    }

    private void OnDrawGizmos()
    {
        if (!DebugModus || _wallChecks == null)
            return;

        Gizmos.color = Application.isPlaying && _isTouchingWall ? Color.green : Color.red;
        for (int i = 0; i < _wallChecks.Length; i++)
        {
            Vector3 position = transform.position;
            position.y += _wallChecks[i]._boxOffset.y;
            position.x += _wallChecks[i]._boxOffset.x;

            Gizmos.DrawWireCube(position, _wallChecks[i]._boxSize);
        }

    }
}
