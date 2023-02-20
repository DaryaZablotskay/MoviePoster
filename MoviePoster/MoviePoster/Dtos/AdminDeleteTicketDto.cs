using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class AdminDeleteTicketDto
    {
        public string FilmName { get; set; }
        public int Hall { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
