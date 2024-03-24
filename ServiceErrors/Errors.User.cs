using ErrorOr;

namespace cs_test.ServiceErrors;

public static class Errors
{
    public static class User
    {
        // public static Error InvalidName => Error.Validation(
        //     code: "User.InvalidName",
        //     description: $"User name must be at least {Models.User.MinNameLength}" +
        //         $" characters long and at most {Models.User.MaxNameLength} characters long.");

        // public static Error InvalidDescription => Error.Validation(
        //     code: "User.InvalidDescription",
        //     description: $"User description must be at least {Models.User.MinDescriptionLength}" +
        //         $" characters long and at most {Models.User.MaxDescriptionLength} characters long.");

        public static Error NotFound => Error.NotFound(
            code: "User.NotFound",
            description: "User not found");
    }
}