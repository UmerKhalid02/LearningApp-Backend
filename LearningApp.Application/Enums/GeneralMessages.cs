﻿namespace LearningApp.Application.Enums
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

        public const string InvalidTopicId = "Invalid TopicID";
        public const string InvalidProblemId = "Invalid ProblemID";
        public const string InvalidChoiceId = "Invalid ChoiceID";

        public const string InvalidProblemType = "Invalid Problem Type";

        public const string ChoiceIdError = "ChoiceId must be provided to update them";
        public const string InvalidChoiceIds = "Provided ChoiceID(s) is/are invalid";
        public const string InvalidChoiceCountMCQ = "Choices for a given problem must be 4";
        public const string InvalidChoiceCountTF = "Choices for a given problem must be 2";
        public const string ProvideChoicesError = "Choices must be provided for the type MCQ/TF";
    }
}
