namespace UserServiceApiV2.Entities
{
    public class AccessRule
    {
        public int Id { get; set; }

        public string RuleName { get; set; } = string.Empty;

        public bool Permission { get; set; } = false;

    }
}
