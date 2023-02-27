using GroepC.Enemies;
using UnityEngine;

/// <summary>
/// Receives the enemy animation events.
/// </summary>
public class AttackEventReciever : MonoBehaviour
{
    /// <summary>
    /// Base enemy script.
    /// </summary>
    [SerializeField]
    private EnemyMovement enemyBase;

    /// <summary>
    /// Event that wil be called.
    /// </summary>
    public void DisableAttacking()
    {
        enemyBase.DisableAttacking();
    }
}
