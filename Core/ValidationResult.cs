namespace Core
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            IsValid = true;
        }

        public ValidationResult(string message)
        {
            IsValid = false;
            Message = message;
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}