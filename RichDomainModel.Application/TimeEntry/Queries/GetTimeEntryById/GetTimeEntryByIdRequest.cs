using MediatR;

namespace RichDomainModel.Application.TimeEntry.Queries.GetTimeEntryById;

public record GetTimeEntryByIdRequest : IRequest<GetTimeEntryByIdResponse>
{
    /// <summary>
    /// Time entry id
    /// </summary>
    public required Guid Id { get; init; }   
}