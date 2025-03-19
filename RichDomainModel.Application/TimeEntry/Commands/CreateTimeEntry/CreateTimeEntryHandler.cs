using Mapster;
using MediatR;
using RichDomainModel.Application.Seedwork.Repositories;
using RichDomainModel.Application.Seedwork.Repositories.Seedwork;
using RichDomainModel.Application.TimeEntry.Shared;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Application.TimeEntry.Commands.CreateTimeEntry;

public class CreateTimeEntryHandler(ITagRepository tagRepository, ICommandRepository commandRepository) : IRequestHandler<CreateTimeEntryRequest, CreateTimeEntryResponse>
{
    public async Task<CreateTimeEntryResponse> Handle(CreateTimeEntryRequest request, CancellationToken cancellationToken)
    {
        // var tagIds = request.Tags.Select(x => new TagId(x)).ToList();
        // var tags = await tagRepository.GetByIds(tagIds);
        
        var timeEntry = TimeEntryAggregate.Create(
            TimeEntryDescription.Create(request.Description),
            TimeEntryTimer.Create(request.StartTime, request.EndTime),
            request.IsBillable);
        
        // TODO: Id is incorrect in the database
        var result = await commandRepository.AddAsync(timeEntry, cancellationToken);
        // TODO: Response is not mapped correctly
        return result.Adapt<TimeEntryAggregate, CreateTimeEntryResponse>();
    }
}