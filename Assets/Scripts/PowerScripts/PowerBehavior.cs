using UnityEngine;

public abstract class PowerBehavior : MonoBehaviour
{
    protected PlayerPowerController player;

    public virtual void Initialize(PlayerPowerController player)
    {
        this.player = player;
    }

    public abstract void Activate();
}
