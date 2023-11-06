using FluentValidation.Results;
using System.Runtime.Serialization;


namespace PlanningsTool.BLL.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public ValidationException(string message) : this(message, Enumerable.Empty<ValidationFailure>())
        {        
        }

        public ValidationException(string message, IEnumerable<ValidationFailure> errors) : base(message)
        {
            Errors = errors;
        }

        public ValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage)
            : base(appendDefaultMessage ? $"{message} {BuildErrorMessage(errors)}" : message)
        {
            Errors = errors;
        }

        public ValidationException(IEnumerable<ValidationFailure> errors) : base(BuildErrorMessage(errors))
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            var arr = errors.Select(x => $"{Environment.NewLine}{x.ErrorMessage}");
            return string.Join(string.Empty, arr);
        }

        public ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Errors = info.GetValue("errors", typeof(IEnumerable<ValidationFailure>)) as IEnumerable<ValidationFailure>;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null) throw new ArgumentNullException("info");

            info.AddValue("errors", Errors);
            base.GetObjectData(info, context);
        }
    }
}
