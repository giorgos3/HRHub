﻿using MediatR;
using HRHub.Domain.Abstractions;

namespace HRHub.Application.Abstractions.Messaging
{
    internal interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
        where TCommand : ICommand<TResponse>
    {   
    }
}
