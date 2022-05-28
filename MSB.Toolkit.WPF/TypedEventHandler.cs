namespace MSB.Toolkit.WPF
{
    /// <summary>
    /// Represents a method that handles general events.
    /// </summary>
    /// <typeparam name="TEventArgs"></typeparam>
    /// <param name="sender">The event source.</param>
    /// <param name="args">The event data. If there is no event data, this parameter will be null.</param>
    public delegate void TypedEventHandler<TEventArgs>(object sender, TEventArgs args);

    /// <summary>
    /// Represents a method that handles general events.
    /// </summary>
    /// <typeparam name="TSender"></typeparam>
    /// <typeparam name="TEventArgs"></typeparam>
    /// <param name="sender">The event source.</param>
    /// <param name="args">The event data. If there is no event data, this parameter will be null.</param>
    public delegate void TypedEventHandler<TSender, TEventArgs>(TSender sender, TEventArgs args);
}
