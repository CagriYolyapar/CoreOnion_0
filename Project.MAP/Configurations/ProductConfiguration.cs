﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configurations
{
    public class ProductConfiguration:BaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.UnitPrice).HasColumnType("money");
        }
    }
}
