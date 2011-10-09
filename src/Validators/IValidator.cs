namespace AutomatedW3cValidator.Validators
{
    public interface IValidator
    {
        ValidatorType ValidatorType { get; set; }
        string Url { get; set; }
        void Validate();
    }
}