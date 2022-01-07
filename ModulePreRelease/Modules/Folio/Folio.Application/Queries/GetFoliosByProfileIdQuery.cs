using Folio.Application.Contract.Internal;

namespace Folio.Application.Queries;

public class GetFoliosByProfileIdQuery : IQueryForPlural<FolioDto>
{
    public Guid ProfileId { get; set; }

    public GetFoliosByProfileIdQuery(Guid id)
    {
        ProfileId = id;
    }
}