namespace DesignPatternsDemo.Shared
{
    public class MenuItem
    {
        public string Key { get; }
        public string Description { get; }
        public Action Action { get; }

        public MenuItem(string key, string description, Action action)
        {
            Key = key;
            Description = description;
            Action = action;
        }

    }
}