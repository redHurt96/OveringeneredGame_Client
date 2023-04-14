using System;

[Serializable]
public struct CreateCharacterMessage
{
    public float X;
    public float Y;
    public float Z;
}

[Serializable]
public struct MoveCharacterMessage
{
    public float X;
    public float Y;
    public float Z;
}
