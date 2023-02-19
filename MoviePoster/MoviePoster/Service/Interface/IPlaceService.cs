using MoviePoster.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Service.Interface
{
    public interface IPlaceService
    {
        Task<IEnumerable<PlacesDto>> GetFreePlaces(Guid oneFilmId, Guid showDateId);
        Task AddPlaces(AdminAddAndDeletePlaceDto entity);
        Task DeletePlace(AdminAddAndDeletePlaceDto entity);
    }
}
