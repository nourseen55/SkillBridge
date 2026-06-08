namespace SkillBridge.Infrastructure.Identity;

public static class RolePermissions
{
    public static List<string> GetPermissions(string role)
    {
        return role switch
        {
            "Student" => new()
            {
                "Course.View",
                "Quiz.Solve"
            },

            "Company" => new()
            {
                "Internship.Create",
                "Applicants.View"
            },

            "Admin" => new()
            {
            },

            _ => new()
        };
    }
}