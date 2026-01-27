using UnityEngine;

public abstract class PowerBehavior : MonoBehaviour
{
    protected PlayerPowerController player;

    public virtual void Initialize(PlayerPowerController player)
    {
        this.player = player;
    }

    // Vì bên trong Scriptable Object không thể triển khai update
    // và thực thi logic runtime khó nên Activate này sẽ dùng để chứa logic của power  
    public abstract void Activate();
}
