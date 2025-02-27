﻿using FluentValidation;

using SFC.Invite.Application.Features.Common.Dto.Common;

namespace SFC.Invite.Application.Features.Common.Validators.Common;

/// <summary>
/// Sorting validator.
/// </summary>
public class SortingValidator : AbstractValidator<SortingDto>
{
    public SortingValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithName(nameof(SortingDto.Name));

        RuleFor(p => p.Direction)
            .IsInEnum()
            .WithName(nameof(SortingDto.Direction));
    }
}
