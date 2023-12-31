﻿using GraphQL_API.Data;

namespace GraphQL_API.Services.Interfaces
{
    public interface IFilmDataService
    {
        List<Film> GetFilms(int numFilms, CancellationToken cancellationToken = default);
    }
}
