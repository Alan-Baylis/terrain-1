using UnityEngine;
using XInputDotNetPure;

public class PlayerControl : MonoBehaviour
{
    PlayerIndex player;
    public GamePadState state;

    private void Update()
    {
        PlayerIndex player = PlayerIndex.One;
        state = GamePad.GetState(player);
        GamePad.SetVibration(player, state.Triggers.Left, state.Triggers.Right);
    }
}
