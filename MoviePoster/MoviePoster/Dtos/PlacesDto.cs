using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class PlacesDto
    {
        public Guid FilmDtoId { get; set; }
        public Guid ShowDateDtoId { get; set; }
        public Guid PlaceDtoId { get; set; }
        public Guid? UserDtoId { get; set; }
        public int HallDto { get; set; }
        public int RowNumberDto { get; set; }
        public int SeatNumberDto { get; set; }
    }
}
