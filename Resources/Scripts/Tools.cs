using Godot;

public static class Tools
{
    const float RainbowBaseSpeed = 0.0002f;
    public static Color RainbowColor(float speed = 1f, float saturation = 1f, float value = 1f)
    {
        float hue = ((float) Time.GetTicksMsec() * RainbowBaseSpeed * speed) % 1;
        return Color.FromHsv(hue, saturation, value);
    }
}