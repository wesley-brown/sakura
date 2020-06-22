namespace Sakura.Interactions
{
    /// <summary>
    /// A condition for an interaction.
    /// </summary>
    public interface Condition
    {
        bool IsTrue { get; }
    }
}
