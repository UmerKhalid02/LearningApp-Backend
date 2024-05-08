namespace LearningApp.Application.Enums
{
    public static class GeneralMessages
    {
        public const string RecordAdded = "Record has been added successfully";
        public const string RecordNotAdded = "Record not added successfully";
        public const string RecordUpdated = "Record has been updated successfully";
        public const string RecordAddedUpdated = "Record has been added/updated successfully";
        public const string RecordNotUpdated = "Record not updated successfully";
        public const string RecordDeleted = "Record has been deleted successfully";
        public const string RecordNotDeleted = "Record not deleted successfully";
        public const string RecordFetched = "Record has been fetched successfully";
        public const string RecordNotFetched = "Record not fetched successfully";
        public const string RecordNotFound = "Record not found";
        
        public const string UsernameExists = "User with this username already exists";
        public const string EmailExists = "User with this email already exists";
        public const string PasswordMatchError = "Password and Confirm Password do not match";
        public const string InvalidRole = "Invalid Role";
        public const string RegisterationSuccessful = "Registeration Successful";

        public const string InvalidTopicId = "Invalid TopicID";
        public const string InvalidProblemId = "Invalid ProblemID";
        public const string InvalidChoiceId = "Invalid ChoiceID";

        public const string InvalidProblemType = "Invalid Problem Type";

        public const string ChoiceIdError = "ChoiceId must be provided to update them";
        public const string InvalidChoiceIds = "Provided ChoiceID(s) is/are invalid";
        public const string InvalidChoiceCountMCQ = "Choices for a given problem must be 4";
        public const string InvalidChoiceCountTF = "Choices for a given problem must be 2";
        public const string ProvideChoicesError = "Choices must be provided for the type MCQ/TF";
        
        
        public const string TopicExists = "Topic with this name already exists";
        public const string TopicsNotAdded = "Topics not added yet";

        public const string TokenIssue = "Something went wrong with token...";
        public const string InvalidToken = "Invalid access token";

        public const string InvalidLessonId = "Invalid LessonID";
        public const string LessonNumberExists = "Lesson with that lesson number already exists under the desired topic";


        public const string UserLoggedInSuccessMessage = "Logged in Successfully.";
        public const string UserLogoutSuccessMessage = "Logged out Successfully.";
        public const string UserLogoutFailMessage = "Logged out fail.";
        public const string UserLoginFail = "Invalid username/email or password";
        public const string UnauthorizedAccess = "You are not authorized";


        public const string InvalidClassroomId = "Invalid Classroom Id";
        public const string TopicAddedInClassroom = "Topic successfully added in classroom";
    }
}
