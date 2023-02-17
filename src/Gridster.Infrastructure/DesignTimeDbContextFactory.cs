// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Microsoft.Extensions.DependencyInjection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GridsterDbContext>
{
    public GridsterDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<GridsterDbContext>();

        builder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Gridster;Integrated Security=SSPI;");

        return new GridsterDbContext(builder.Options);
    }
}