public interface IGunInput
{
    void ReadInput();
    bool IsFiring { get; }
    bool ResetFire { get; }
}