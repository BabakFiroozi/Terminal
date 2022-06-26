using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private NetworkTransform _tr;

    public static Player LocalPlayer;

    [SerializeField] private MeshRenderer _ren;

    private void Awake()
    {
        _tr = GetComponent<NetworkTransform>();
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            _tr.Transform.Translate(5 * data.direction * Runner.DeltaTime);
        }
    }

    public override void Spawned()
    {
        base.Spawned();

        if (Object.HasInputAuthority)
        {
            LocalPlayer = this;
            _ren.material.color = Color.green;
        }
        else
        {
            _ren.material.color = Color.red;
        }
    }
}
