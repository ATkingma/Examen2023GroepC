using UnityEngine;

/// <summary>
/// This class will activate an animation when an public void is called
/// </summary>
public class AnimationActivator : MonoBehaviour
{
    /// <summary>
    /// The animator that wil be called.
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// The parametername of the parameter that wil be set true.
    /// </summary>
    [SerializeField]
    private string parameterName;

    /// <summary>
    /// The type of parameter this way you can switch between trigger and bool.
    /// </summary>
    [SerializeField]
    private ParameterType parameterType;

    /// <summary>
    /// Activated the given paramter on the animator.
    /// </summary>
    public void ActivateAnimation()
    {
        switch (parameterType)
        {
            case ParameterType.Bool:
                animator.SetBool(parameterName, true);
                break;
            case ParameterType.Trigger:
                animator.SetTrigger(parameterName);
            break;
        }
    }
}


/// <summary>
/// Parameter types.
/// </summary>
enum ParameterType
{
    none,
    Bool,
    Trigger,
}
