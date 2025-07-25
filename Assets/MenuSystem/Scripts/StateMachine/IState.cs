public interface IState
{
    string Name { get; }
    bool IsOn { get; }
    void SwitchOn();
    void SwitchOff();
}