using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Application.Contract.Data;

public sealed record SearchData(
    string? SearchText,
    int? PageSize,
    int? PageIndex,
    string? Sort
);
