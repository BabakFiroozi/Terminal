using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private NetworkCharacterControllerPrototype _cc;

    public static Player LocalPlayer;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            _cc.Move(5 * data.direction * Runner.DeltaTime);
        }
    }

    public override void Spawned()
    {
        base.Spawned();
    }
}
