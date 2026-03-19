namespace Web.WebComponent
{
    public class TreeNode
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ParentID { get; set; }
        public bool IsChecked { get; set; }
        public bool IsExpanded { get; set; }
        public List<TreeNode> Children { get; set; } = new();
    }
}
