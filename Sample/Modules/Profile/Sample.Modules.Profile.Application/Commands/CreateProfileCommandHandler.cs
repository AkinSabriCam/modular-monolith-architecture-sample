using MediatR;
using Sample.Modules.Profile.Domain.Profile;
using Sample.Modules.Profile.Domain.Profile.Dtos;

namespace Sample.Modules.Profile.Application.Commands;

public class CreateProfileCommandHandler : AsyncRequestHandler<CreateProfileCommand>
{
    private readonly IProfileDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProfileCommandHandler(IProfileDomainService domainService, IUnitOfWork unitOfWork)
    {
        _domainService = domainService;
        _unitOfWork = unitOfWork;
    }

    protected override async Task Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var prof = await _domainService.Create(
            new CreateProfileDto(request.FirstName, request.LastName, request.Type )
        );

        await _unitOfWork.SaveChangesAsync();
    }
}