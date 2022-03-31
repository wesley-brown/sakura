namespace Sakura.Bodies.Movements.Creations
{
    /// <summary>
    ///     The input port for a movement creation system.
    /// </summary>
    public interface InputPort
    {
        /// <summary>
        ///     Create a movement based on the given input.
        /// </summary>
        /// <param name="input">
        ///     The input to creation the movement with.
        /// </param>
        void Move(Input input);
    }
}
