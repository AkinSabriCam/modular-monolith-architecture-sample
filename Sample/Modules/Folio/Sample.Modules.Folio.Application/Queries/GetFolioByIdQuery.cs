using Sample.Modules.Folio.Application.Contract.Internal;

namespace Sample.Modules.Folio.Application.Queries;

public class GetFolioByIdQuery : IQuery<FolioDto>
{
    public Guid Id { get; private set; }

    public GetFolioByIdQuery(Guid id)
    {
        Id = id;
    }
}