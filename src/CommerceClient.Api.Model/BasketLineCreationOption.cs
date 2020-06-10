namespace CommerceClient.Api.Model
{
    /// <summary>
    /// Enum controlling how to alter default basket line creation behaviour (update or new)
    /// </summary>
    public enum BasketLineCreationOption
    {
        Default = 0,

        /// <summary>
        /// Forces creation of a new line, even if there is a line in basket that only differs in quantity.
        /// </summary>
        CreateNewLine = 1
    }
}