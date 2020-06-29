using UnityEngine;

public class Controllers
{
    public static KeyCode FirstPlayerShootKey = KeyCode.E;
    public static KeyCode FirstPlayerLeft = KeyCode.A;
    public static KeyCode FirstPlayerRight = KeyCode.D;

    public static KeyCode SecondPlayerShootKey = KeyCode.RightShift;
    public static KeyCode SecondPlayerLeft = KeyCode.LeftArrow;
    public static KeyCode SecondPlayerRight = KeyCode.RightArrow;
    
    public static string GetFirstPlayerShootKey()
    {
        return "Shoot - E";
    }

    public static string GetFirstPlayerLeftKey()
    {
        return "Move Left - A";
    }

    public static string GetFirstPlayerRightKey()
    {
        return "Move Right - D";
    }

    public static string GetSecondPlayerShootKey()
    {
        return "Shoot - Right Shift";
    }

    public static string GetSecondPlayerLeftKey()
    {
        return "Move Left - Left Arrow";
    }

    public static string GetSecondPlayerRightKey()
    {
        return "Move Right - Right Arrow";
    }
}
