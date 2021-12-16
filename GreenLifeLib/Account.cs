using System;

namespace GreenLifeLib
{
    public class Account
    {
        public int Id { get; set; }
        public int Login { get; set; }
        //TODO: Password must be in HashCode
        public string Password { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public enum Sex
        {
            Male,
            Female
        }
        public Sex UserSex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegDate { get; set; }
        public Role UserRole { get; set; }
        public User User { get; set; }
    }
}
