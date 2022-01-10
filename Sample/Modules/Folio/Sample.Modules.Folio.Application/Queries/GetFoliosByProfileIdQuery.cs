using Sample.Modules.Folio.Application.Contract.Internal;

namespace Sample.Modules.Folio.Application.Queries;

public class GetFoliosByProfileIdQuery : IQuery<List<FolioDto>>
{
    public Guid ProfileId { get; set; }

    public GetFoliosByProfileIdQuery(Guid id)
    {
        ProfileId = id;
    }
}