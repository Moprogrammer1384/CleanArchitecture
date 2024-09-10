using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Application.Dtos.Commons;

public sealed record SearchDataDto(
    string? SearchText,
    int? PageSize,
    int? PageIndex,
    string? Sort
);
