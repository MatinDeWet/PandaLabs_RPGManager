using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Common.Validation
{
    public class HtmlInputValidator : AbstractValidator<string?>
    {
        public HtmlInputValidator()
        {
            RuleFor(input => input)
                .Must(BeValidHtml)
                .WithMessage("{PropertyName} contains disallowed scripts or malicious code.");
        }

        private bool BeValidHtml(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;

            // Regular expressions to detect <script> tags and inline event handlers like onclick
            var scriptTagPattern = @"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>";
            var eventHandlerPattern = @"on\w+=(""[^""]*""|'[^']*'|[^>\s]*)";

            var scriptTagRegex = new Regex(scriptTagPattern, RegexOptions.IgnoreCase);
            var eventHandlerRegex = new Regex(eventHandlerPattern, RegexOptions.IgnoreCase);

            return !scriptTagRegex.IsMatch(input) && !eventHandlerRegex.IsMatch(input);
        }
    }
}
