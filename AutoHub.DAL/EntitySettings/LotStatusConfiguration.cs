﻿using AutoHub.DAL.Entities;
using AutoHub.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace AutoHub.DAL.EntitySettings
{
    public class LotStatusConfiguration
    {
        public LotStatusConfiguration(EntityTypeBuilder<LotStatus> entity)
        {
            entity.ToTable("LotStatus").HasKey(status => status.LotStatusId);

            entity.HasData(
                Enum.GetValues(typeof(LotStatusEnum))
                    .Cast<LotStatusEnum>()
                    .Select(s => new LotStatus
                    {
                        LotStatusId = s,
                        LotStatusName = s.ToString()
                    }));

            entity.HasMany(status => status.Lots)
                .WithOne(lot => lot.LotStatus)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}