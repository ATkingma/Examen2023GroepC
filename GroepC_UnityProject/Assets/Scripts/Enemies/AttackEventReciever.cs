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

    /// <summary>
    /// Event that wil be called.
    /// </summary>
    public void EnableAttacking()
    {
        enemyBase.EnableAttacking();
    }

    /// <summary>
    /// The base enemy script had 3 types of audio and this wil be played from index 0 - 2
    /// </summary>
    /// <param name="index"></param>
    public void PlayAttackAudio(int index)
    {
        enemyBase.PlayAttackSound(index);
    }
}
