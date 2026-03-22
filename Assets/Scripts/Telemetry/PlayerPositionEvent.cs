using Unity.Services.Analytics;

public class PlayerPositionEvent : Event
{
    public PlayerPositionEvent(float x, float y) : base("player_position")
    {
        SetParameter("x", x);
        SetParameter("y", y);
    }
}
