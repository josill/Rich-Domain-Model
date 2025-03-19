using FluentValidation;

namespace RichDomainModel.Application.TimeEntry.Commands.CreateTimeEntry;

public class CreateTimeEntryRequestValidator : AbstractValidator<CreateTimeEntryRequest>
{
    public CreateTimeEntryRequestValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.StartTime);
        RuleFor(x => x.EndTime);
        RuleFor(x => x).Must(x => x.StartTime < x.EndTime);
        RuleFor(x => x.IsBillable).NotEmpty();
        RuleFor(x => x.Tags).NotEmpty();
        RuleForEach(x => x.Tags).NotEqual(Guid.Empty);
    }
}