namespace Application.BaseValidator
{
    public static class ValidatorMessages
    {
        public static string NotEmptyMessage { get; } = "{PropertyName} cannot be blank";
        public static string NotNullMessage { get; } = "{PropertyName} cannot be passed null";
        public static string IdNotEqualToZero { get; } = "{PropertyName} cannot be equal to zero";

    }
}
