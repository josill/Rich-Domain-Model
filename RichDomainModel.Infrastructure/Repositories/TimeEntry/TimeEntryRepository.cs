using RichDomainModel.Application.Seedwork.Repositories;
using RichDomainModel.Infrastructure.Repositories.Seedwork;

namespace RichDomainModel.Infrastructure.Repositories.TimeEntry;

public class TimeEntryRepository(IAppDbContext context) : QueryRepository(context), ITimeEntryRepository;