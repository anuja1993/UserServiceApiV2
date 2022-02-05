namespace UserServiceApiV2.Entities
{
    public class User : Person
    {
        public int CustomerId { get; set; }

        public UserGroup UserGroup { get; set; } = new UserGroup();

    }
}
