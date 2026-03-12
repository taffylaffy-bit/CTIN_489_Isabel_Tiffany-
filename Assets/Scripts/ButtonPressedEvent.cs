using Unity.Services.Analytics;

public class ButtonPressedEvent : Event
{
    public ButtonPressedEvent(string buttonName) : base("button_pressed")
    {
        SetParameter("button_name", buttonName);
    }
}