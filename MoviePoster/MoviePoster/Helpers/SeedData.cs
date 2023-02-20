using MoviePoster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Helpers
{
    public static class SeedData
    {
        public static Film[] GenerateFilms()
        {
            var films = new Film[]
            {
                new Film
                {
                    FilmId = new Guid("b5472944-f5a3-49e7-a0f4-2356a2f65fe1"),
                    Name = "На краю",
                    Genre = "Триллер",
                    AgeLimit =16,
                    Duration = 86,
                    Description ="Альпинистка Келли становится свидетелем убийства подруги. Она успевает снять происходящее на камеру, но ее замечают. Девушка отправляется к неприступной скале, надеясь там скрыться от убийц. Но она не подозревает, с какими трудностями ей придется столкнуться во время подъема на вершину и что ее убежище может стать настоящей ловушкой.",
                    PictureUrl = "https://img.afisha.me/media/340x0s/cover/01/b/na-krayu-2029754.jpg",
                    Rating = 5.5,
                    Price = 14
                },
                new Film
                {
                    FilmId= new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"),
                    Name = "Заговор дьявола",
                    Genre = "Триллер, ужасы",
                    AgeLimit =18,
                    Duration = 110,
                    Description ="В биотехнологической лаборатории научились клонировать великих исторических деятелей. С тех пор были организованы подпольные аукционы клонов таких личностей как Микеланджело, Галилей и Вивальди. Однако сатанинский культ, который стоит за биолабораторией, интересуют не только деньги, поэтому они похищают Туринскую плащаницу. Заполучив таким образом ДНК, они планируют оплодотворить американку Лауру, чтобы она родила клона Христа, который они хотят преподнести Дьяволу.",
                    PictureUrl = "https://img.afisha.me/media/340x0s/cover/05/c/zagovor-dyavola-411199.jpg",
                    Rating = 4.8,
                    Price = 17
                },
                new Film
                {
                    FilmId= new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    Name = "Операция «Фортуна»: Искусство Побеждать",
                    Genre = "Триллер, боевик",
                    AgeLimit =12,
                    Duration = 110,
                    Description ="Элитный разведчик Орсон Форчун получил новое задание: остановить продажу и распространение смертельного оружия. Но в одиночку ему эту миссию не потянуть. Он вынужден объединиться с лучшими оперативниками мира, а также известным киноактером, который предоставит лихой группе убедительное прикрытие. На кону судьба человечества, но на этот раз супершпионам придется играть по правилам Голливуда.",
                    PictureUrl = "https://img.afisha.me/media/340x0s/cover/05/d/operaciya-fortuna-iskusstvo-pobezhdat-6735695.jpg",
                    Rating = 6.9,
                    Price = 15
                },
                new Film
                {
                    FilmId = new Guid("779d34c6-8364-4104-9420-7a47b6dd76b8"),
                    Name = "Элвис",
                    Genre = "Биография, драма",
                    AgeLimit =12,
                    Duration = 160,
                    Description ="История жизни и творческого пути короля рок-н-ролла Элвиса Пресли через призму сложных взаимоотношений с его одиозным менеджером, полковником Томом Паркером. Они работали вместе более 20 лет: от начала карьеры Элвиса до его небывалой славы.",
                    PictureUrl = "https://img.afisha.me/media/340x0s/cover/04/5/elvis-471555.jpg",
                    Rating = 7.3,
                    Price = 9
                },
                new Film
                {
                    FilmId = new Guid("46c50705-c9bc-4f16-a122-49142cb05cb7"),
                    Name = "Крушение",
                    Genre = "Триллер, боевик",
                    AgeLimit =16,
                    Duration = 100,
                    Description ="Пилоту Броуди Торрансу удаётся успешно посадить повреждённый штормом самолёт на враждебной территории. Вскоре выясняется, что уцелевшим угрожают воинствующие пираты, которые хотят захватить самолёт и его пассажиров в заложники. Пока идут поиски пропавшего самолёта, Броуди должен защитить своих пассажиров, пока не прибудет помощь.",
                    PictureUrl = "https://img.afisha.me/media/340x0s/cover/0b/e/krushenie-593933.jpg",
                    Rating = 7.0,
                    Price = 15
                }
            };
            return films;
        }

        public static ShowDate[] GenerateShowDates()
        {
            var showDates = new ShowDate[]
            {
                new ShowDate
                {
                    ShowDateId = new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"),
                    Date = new DateTime(2023, 2, 3, 10,0,0)
                },
                new ShowDate
                {
                    ShowDateId = new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"),
                    Date = new DateTime(2023, 2, 3, 14,0,0)
                },
                new ShowDate
                {
                    ShowDateId = new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"),
                    Date = new DateTime(2023, 2, 3, 18,0,0)
                },
                new ShowDate
                {
                    ShowDateId = new Guid("0b253034-363c-4773-a2f4-580a64ac8314"),
                    Date = new DateTime(2023, 2, 3, 22,0,0)
                }
            };
            return showDates;
        }

        public static Place[] GeneratePlaces()
        {
            var places = new Place[]
            {
                new Place
                {
                    PlaceId = new Guid("bb03b2c7-ca1a-4bfa-bced-a398b9dab90f"),
                    Hall = 1,
                    RowNumber =1,
                    SeatNumber =1,
                },
                new Place
                {
                    PlaceId = new Guid("24c523fc-7f04-40b2-9496-25d085de0584"),
                    Hall = 1,
                    RowNumber =1,
                    SeatNumber =2
                },
                new Place
                {
                    PlaceId = new Guid("b44283ae-a373-4365-b424-7cf6c6e460cd"),
                    Hall = 1,
                    RowNumber =2,
                    SeatNumber =1
                },
                new Place
                {
                    PlaceId = new Guid("9e28f3da-c04d-4779-8541-f58dbf0dabe9"),
                    Hall = 1,
                    RowNumber =2,
                    SeatNumber =2
                },
                new Place
                {
                    PlaceId = new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0"),
                    Hall = 2,
                    RowNumber =1,
                    SeatNumber =1
                },
                new Place
                {
                    PlaceId = new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b"),
                    Hall = 2,
                    RowNumber =2,
                    SeatNumber =1
                }
            };
            return places;
        }

        public static Ticket[] GenerateTickets()
        {
            var tickets = new Ticket[]
            {
                new Ticket
                {
                    TicketId = new Guid("18b296d4-8b88-4d79-aacc-3e61f6ff5b0e"),
                    FilmId = new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    ShowDateId = new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"),
                    PlaceId = new Guid("bb03b2c7-ca1a-4bfa-bced-a398b9dab90f")
                },
                new Ticket
                {
                    TicketId = new Guid("72560a5e-8839-4255-a8bd-3c6c0bc9ceff"),
                    FilmId = new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    ShowDateId = new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"),
                    PlaceId = new Guid("24c523fc-7f04-40b2-9496-25d085de0584")
                },
                new Ticket
                {
                    TicketId = new Guid("d14b456a-5a8b-48f2-91cc-0e72367abbf9"),
                    FilmId = new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    ShowDateId = new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"),
                    PlaceId = new Guid("b44283ae-a373-4365-b424-7cf6c6e460cd")
                },
                new Ticket
                {
                    TicketId = new Guid("f8e75076-4a24-4b59-b0ac-3a0623144d0e"),
                    FilmId = new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    ShowDateId = new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"),
                    PlaceId = new Guid("9e28f3da-c04d-4779-8541-f58dbf0dabe9")
                },
                new Ticket
                {
                    TicketId = new Guid("93a51970-c1bf-4d95-941b-fc46f7de5238"),
                    FilmId = new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    ShowDateId = new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"),
                    PlaceId = new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0")
                },
                new Ticket
                {
                    TicketId = new Guid("4c679964-f1a0-44b3-8d11-fe2f95611d04"),
                    FilmId = new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"),
                    ShowDateId = new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"),
                    PlaceId = new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b")
                },
                new Ticket
                {
                    TicketId = new Guid("a20d1f13-8ad5-4658-a6db-534344a5e51e"),
                    FilmId = new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"),
                    ShowDateId = new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"),
                    PlaceId = new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0")
                },
                new Ticket
                {
                    TicketId = new Guid("faef8963-cac2-4794-a4b2-67d419fd7bb1"),
                    FilmId = new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"),
                    ShowDateId = new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"),
                    PlaceId = new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b")
                },
                new Ticket
                {
                    TicketId = new Guid("a386c489-67ef-4810-8316-c8bf9a639bfa"),
                    FilmId = new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"),
                    ShowDateId = new Guid("0b253034-363c-4773-a2f4-580a64ac8314"),
                    PlaceId = new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0")
                },
                new Ticket
                {
                    TicketId = new Guid("e65e4461-8d9e-4c8a-8018-5f96add29c4a"),
                    FilmId = new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"),
                    ShowDateId = new Guid("0b253034-363c-4773-a2f4-580a64ac8314"),
                    PlaceId = new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b")
                }
            };
            return tickets;
        }

        public static Role[] GenerateRoles()
        {
            var roles = new Role[]
            {
                new Role
                {
                    RoleId = new Guid("5c132ec5-7b5c-44c0-83b5-a092829f2607"),
                    Name="admin"
                },
                new Role
                {
                    RoleId = new Guid("0f7d5eb9-99a2-46b5-813f-84e6420f48a2"),
                    Name = "user"
                }
            };
            return roles;
        }

        public static User GenerateAdmin()
        {
            var admin = new User
            {
                UserId = new Guid("d9232052-926d-4316-b4f5-98cc6136d73a"),
                FirstName = "Дарья",
                LastName = "Заблоцкая",
                Email = "dasaz659@gmail.com",
                Password = "12345678",
                RoleId = new Guid("5c132ec5-7b5c-44c0-83b5-a092829f2607")
            };
            return admin;
        }
    }
}
