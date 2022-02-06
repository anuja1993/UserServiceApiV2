namespace UserServiceApiV2.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }

        public string GroupName { get; set; } = string.Empty;

        public int AccessRuleId { get; set; }

        public AccessRule? AccessRule { get; set; }
    }
}
