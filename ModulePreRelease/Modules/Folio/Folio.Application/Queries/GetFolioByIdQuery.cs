using Folio.Application.Contract.Internal;

namespace Folio.Application.Queries;

public class GetFolioByIdQuery : IQuery<FolioDto>
{
    public Guid Id { get; private set; }

    public GetFolioByIdQuery(Guid id)
    {
        Id = id;
    }
}