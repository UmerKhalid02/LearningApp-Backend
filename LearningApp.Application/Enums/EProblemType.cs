namespace LearningApp.Application.Enums
{
    public enum EProblemType
    {
        MCQ = 1,
        TF = 2,
        FIB = 3,
        CODE = 4,
        MATCH = 5
    }

    public static class EProblemTypeExtensions
    {
        public static string GetProblemTypeStringValue(this EProblemType type)
        {
            return type switch
            {
                EProblemType.MCQ => "MCQ",
                EProblemType.TF => "TF",
                EProblemType.FIB => "FIB",
                EProblemType.CODE => "CODE",
                EProblemType.MATCH => "MATCH",
                _ => "UNKNOWN",
            };
        }

        public static int GetProblemTypeEnumValue(this string type)
        {
            if (string.IsNullOrEmpty(type))
                return 0;

            return type.ToUpper() switch
            {
                "MCQ" => 1,
                "TF" => 2,
                "FIB" => 3,
                "CODE" => 4,
                "MATCH" => 5,
                _ => 0,
            };
        }

        public static bool ProblemTypeIsInvalid(string problemType)
        {
            return !Enum.TryParse(problemType, true, out EProblemType parsedType) || !Enum.IsDefined(typeof(EProblemType), parsedType);
        }
    }
}
