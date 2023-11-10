namespace LearningApp.Application.Enums
{
    public static class RolesKey
    {
        public static readonly Guid AdminRoleId = Guid.Parse("35DC76B5-8DE7-4EB3-A29C-9A05686A6F89");
        public static readonly Guid StudentRoleId = Guid.Parse("2BD8F739-13C4-46E2-B0CC-5888851F373A");
        public static readonly Guid TeacherRoleId = Guid.Parse("BF7669AC-C46A-4DEA-BFA0-8D8AEF1D9347");

        public const string AD = "AD";
        public const string ST = "ST";
        public const string TR = "TR";

        public const string Admin = "Admin";
        public const string Student = "Student";
        public const string Teacher = "Teacher";
    }
}
