namespace Sakura.Bodies.RegisterBody
{
    /// <summary>
    ///     A system that registers bodies to entities.
    /// </summary>
    public interface System
    {
        /// <summary>
        ///     Register a body at a given location for a given entity as
        ///     defined by a given <see cref="Input"/>.
        /// </summary>
        /// <param name="input">
        ///     The <see cref="Input"/>.
        /// </param>
        void Register(Input input);
    }
}
