using System.ComponentModel.DataAnnotations;

namespace UserServiceApiV2.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string Lastname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string GetFullName()
        {
            return FirstName + ' ' + Lastname;
        }

    }
}
