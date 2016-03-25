﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Autofac.Features.OwnedInstances;

using Microsoft.Data.Entity;
using SSW.DataOnion.Interfaces;
using SSW.MusicStore.API.Services.Query.Interfaces;
using SSW.MusicStore.Data.Entities;

namespace SSW.MusicStore.API.Services.Query
{
	public class GenreQueryService : IGenreQueryService
	{
        private readonly Func<Owned<IReadOnlyUnitOfWork>> unitOfWorkFunc;

        public GenreQueryService(Func<Owned<IReadOnlyUnitOfWork>> unitOfWorkFunc)
        {
            this.unitOfWorkFunc = unitOfWorkFunc;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
		{
			using (var unitOfWork = this.unitOfWorkFunc())
			{
			    var genres = await unitOfWork.Value.Repository<Genre>().Get().ToListAsync();
			    return genres;
			}
		}
	}

}
