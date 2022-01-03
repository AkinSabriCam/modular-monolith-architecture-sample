﻿using Autofac;
using Folio.Application.Contract.ContractsForProfile;
using Folio.Infrastructure.Shared;
using MediatR;

namespace Folio.Integration.Profile;

public class FolioExecutorForProfile : IFolioExecutorForProfile
{
    public async Task ExecuteCommand(ICommandForProfile command)
    {
        await using var scope = FolioContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        await mediator.Send(command);
    }

    public async Task<TResponse> ExecuteQuery<TResponse>(IQueryForProfile<TResponse> command)
    {
        await using var scope = FolioContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(command);
    }

    public async Task<List<TResponse>> ExecuteQuery<TResponse>(IQueryForPluralForProfile<TResponse> command)
    {
        await using var scope = FolioContainerProvider.BeginScope();
        var mediator = scope.Resolve<IMediator>();
        return await mediator.Send(command);
    }
}