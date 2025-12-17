/*****************************************************************************
* Project : Monsterkampf-Simulator (K1, S1, S4)
* File    : 
* Date    : xx.xx.2025
* Author  : Eric Rosenberg
*
* Description :
* *
* History :
* xx.xx.2025 ER Created
******************************************************************************/
using UnityEngine;

public class WallCheck : MonoBehaviour
{

    [Header("Options")]
    [Tooltip("Activates the drawing on Gizmos of the Wallckecks")]
    [SerializeField] private bool DebugModus = false;

    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public struct WallCheckData
    {
        [Header("Settings OverLapbox")]
        [Tooltip("Change the Size of the area you want to check")]
        public Vector2 _boxSize;
        [Tooltip("Offset from GameObject to place the Wallcheck")]
        public Vector2 _boxOffset;
        [Tooltip("Target LayerMask which will be ckecked")]
        public LayerMask layerMask;
    }
    //--- Fields ---
    [SerializeField] private WallCheckData[] _wallChecks;
    private bool _isTouchingWall;

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool CheckWall()
    {
        return _isTouchingWall;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private bool CheckOverlap(WallCheckData data)
    {
        Vector2 boxPosition = (Vector2)transform.position + data._boxOffset;
        Collider2D hit = Physics2D.OverlapBox(boxPosition, data._boxSize, 0, data.layerMask);

        return hit != null;
    }

    /// <summary>
    /// 
    /// </summary>
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
