namespace Web.WebComponent
{
    public class ColumnDefinition<TItem>
    {
        public string Title { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public Func<TItem, object> CellTemplate { get; set; } = _ => string.Empty;
    }
}
