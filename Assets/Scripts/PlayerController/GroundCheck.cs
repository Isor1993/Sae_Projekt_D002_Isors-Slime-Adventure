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

//TODO Pvelapbox einbauen zum auswählen
public class GroundCheck : MonoBehaviour
{  
    [Header("Settings OverLapbox")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 _boxSize = new Vector2(1f,0.19f);
    [SerializeField] private Vector2 _boxOffset = new Vector2(0f,0.08f);
    [Header("Debug")]
    [SerializeField] private bool DebugModus = false;

    private bool _isGrounded;  


    private void FixedUpdate()
    {
        _isGrounded = CheckOverlap();
    }

    public bool CheckGround()
    {
        return _isGrounded;
    }

    private bool CheckOverlap()
    {
        Vector2 boxPosition = (Vector2)transform.position + _boxOffset;
        Collider2D hit = Physics2D.OverlapBox(boxPosition, _boxSize,0, _layerMask);

        return hit!=null;
    }

    private void OnDrawGizmos()
    {
        if (DebugModus)
        {
            Vector3 position=transform.position;
            position.y += _boxOffset.y;
            position.x += _boxOffset.x;

            Gizmos.color = Application.isPlaying && _isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireCube(position, _boxSize);
        }
    }
}
