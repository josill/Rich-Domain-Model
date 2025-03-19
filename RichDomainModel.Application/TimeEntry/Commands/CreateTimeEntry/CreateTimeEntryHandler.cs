using Mapster;
using MediatR;
using RichDomainModel.Application.Seedwork.Repositories;
using RichDomainModel.Application.Seedwork.Repositories.Seedwork;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Application.TimeEntry.Commands.CreateTimeEntry;

public class CreateTimeEntryHandler(ITagRepository tagRepository, ICommandRepository commandRepository) : IRequestHandler<CreateTimeEntryRequest, CreateTimeEntryResponse>
{
    public async Task<CreateTimeEntryResponse> Handle(CreateTimeEntryRequest request, CancellationToken cancellationToken)
    {
        var tagIds = request.Tags.Select(x => new TagId(x)).ToList();
        var tags = await tagRepository.GetByIds(tagIds);
        
        var timeEntry = TimeEntryAggregate.Create(
            TimeEntryDescription.Create(request.Description),
            TimeEntryTimer.Create(request.StartTime, request.EndTime),
            request.IsBillable);
        
        var result = await commandRepository.AddAsync(timeEntry, cancellationToken);
        return result.Adapt<TimeEntryAggregate, CreateTimeEntryResponse>();
    }
}