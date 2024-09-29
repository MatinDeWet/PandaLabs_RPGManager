namespace Application.Features.LocationFeatures.Commands.UpdateLocationParent
{
    public class UpdateLocationParentRequestValidator : AbstractValidator<UpdateLocationParentRequest>
    {
        public UpdateLocationParentRequestValidator()
        {
            RuleFor(x => x.ParentId)
                .NotEqual(x => x.Id);
        }
    }
}
