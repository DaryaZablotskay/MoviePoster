using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePoster.Migrations
{
    public partial class PropertyStatusDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: new Guid("46c50705-c9bc-4f16-a122-49142cb05cb7"));

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: new Guid("779d34c6-8364-4104-9420-7a47b6dd76b8"));

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: new Guid("b5472944-f5a3-49e7-a0f4-2356a2f65fe1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("18b296d4-8b88-4d79-aacc-3e61f6ff5b0e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("4c679964-f1a0-44b3-8d11-fe2f95611d04"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("72560a5e-8839-4255-a8bd-3c6c0bc9ceff"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("93a51970-c1bf-4d95-941b-fc46f7de5238"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a20d1f13-8ad5-4658-a6db-534344a5e51e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("a386c489-67ef-4810-8316-c8bf9a639bfa"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("d14b456a-5a8b-48f2-91cc-0e72367abbf9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("e65e4461-8d9e-4c8a-8018-5f96add29c4a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("f8e75076-4a24-4b59-b0ac-3a0623144d0e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("faef8963-cac2-4794-a4b2-67d419fd7bb1"));

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"));

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "FilmId",
                keyValue: new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: new Guid("24c523fc-7f04-40b2-9496-25d085de0584"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: new Guid("9e28f3da-c04d-4779-8541-f58dbf0dabe9"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: new Guid("b44283ae-a373-4365-b424-7cf6c6e460cd"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: new Guid("bb03b2c7-ca1a-4bfa-bced-a398b9dab90f"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "PlaceId",
                keyValue: new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b"));

            migrationBuilder.DeleteData(
                table: "ShowDates",
                keyColumn: "ShowDateId",
                keyValue: new Guid("0b253034-363c-4773-a2f4-580a64ac8314"));

            migrationBuilder.DeleteData(
                table: "ShowDates",
                keyColumn: "ShowDateId",
                keyValue: new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"));

            migrationBuilder.DeleteData(
                table: "ShowDates",
                keyColumn: "ShowDateId",
                keyValue: new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"));

            migrationBuilder.DeleteData(
                table: "ShowDates",
                keyColumn: "ShowDateId",
                keyValue: new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Places");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Places",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "FilmId", "AgeLimit", "Description", "Duration", "Genre", "Name", "PictureUrl", "Price", "Rating" },
                values: new object[,]
                {
                    { new Guid("b5472944-f5a3-49e7-a0f4-2356a2f65fe1"), 16, "Альпинистка Келли становится свидетелем убийства подруги. Она успевает снять происходящее на камеру, но ее замечают. Девушка отправляется к неприступной скале, надеясь там скрыться от убийц. Но она не подозревает, с какими трудностями ей придется столкнуться во время подъема на вершину и что ее убежище может стать настоящей ловушкой.", 86, "Триллер", "На краю", "https://img.afisha.me/media/340x0s/cover/01/b/na-krayu-2029754.jpg", 14, 5.5 },
                    { new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"), 18, "В биотехнологической лаборатории научились клонировать великих исторических деятелей. С тех пор были организованы подпольные аукционы клонов таких личностей как Микеланджело, Галилей и Вивальди. Однако сатанинский культ, который стоит за биолабораторией, интересуют не только деньги, поэтому они похищают Туринскую плащаницу. Заполучив таким образом ДНК, они планируют оплодотворить американку Лауру, чтобы она родила клона Христа, который они хотят преподнести Дьяволу.", 110, "Триллер, ужасы", "Заговор дьявола", "https://img.afisha.me/media/340x0s/cover/05/c/zagovor-dyavola-411199.jpg", 17, 4.7999999999999998 },
                    { new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), 12, "Элитный разведчик Орсон Форчун получил новое задание: остановить продажу и распространение смертельного оружия. Но в одиночку ему эту миссию не потянуть. Он вынужден объединиться с лучшими оперативниками мира, а также известным киноактером, который предоставит лихой группе убедительное прикрытие. На кону судьба человечества, но на этот раз супершпионам придется играть по правилам Голливуда.", 110, "Триллер, боевик", "Операция «Фортуна»: Искусство Побеждать", "https://img.afisha.me/media/340x0s/cover/05/d/operaciya-fortuna-iskusstvo-pobezhdat-6735695.jpg", 15, 6.9000000000000004 },
                    { new Guid("779d34c6-8364-4104-9420-7a47b6dd76b8"), 12, "История жизни и творческого пути короля рок-н-ролла Элвиса Пресли через призму сложных взаимоотношений с его одиозным менеджером, полковником Томом Паркером. Они работали вместе более 20 лет: от начала карьеры Элвиса до его небывалой славы.", 160, "Биография, драма", "Элвис", "https://img.afisha.me/media/340x0s/cover/04/5/elvis-471555.jpg", 9, 7.2999999999999998 },
                    { new Guid("46c50705-c9bc-4f16-a122-49142cb05cb7"), 16, "Пилоту Броуди Торрансу удаётся успешно посадить повреждённый штормом самолёт на враждебной территории. Вскоре выясняется, что уцелевшим угрожают воинствующие пираты, которые хотят захватить самолёт и его пассажиров в заложники. Пока идут поиски пропавшего самолёта, Броуди должен защитить своих пассажиров, пока не прибудет помощь.", 100, "Триллер, боевик", "Крушение", "https://img.afisha.me/media/340x0s/cover/0b/e/krushenie-593933.jpg", 15, 7.0 }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "PlaceId", "Hall", "RowNumber", "SeatNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("bb03b2c7-ca1a-4bfa-bced-a398b9dab90f"), 1, 1, 1, true },
                    { new Guid("24c523fc-7f04-40b2-9496-25d085de0584"), 1, 1, 2, true },
                    { new Guid("b44283ae-a373-4365-b424-7cf6c6e460cd"), 1, 2, 1, true },
                    { new Guid("9e28f3da-c04d-4779-8541-f58dbf0dabe9"), 1, 2, 2, true },
                    { new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0"), 2, 1, 1, true },
                    { new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b"), 1, 2, 1, true }
                });

            migrationBuilder.InsertData(
                table: "ShowDates",
                columns: new[] { "ShowDateId", "Date" },
                values: new object[,]
                {
                    { new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"), new DateTime(2023, 2, 3, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"), new DateTime(2023, 2, 3, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"), new DateTime(2023, 2, 3, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b253034-363c-4773-a2f4-580a64ac8314"), new DateTime(2023, 2, 3, 22, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "FilmId", "PlaceId", "ShowDateId", "UserId" },
                values: new object[,]
                {
                    { new Guid("18b296d4-8b88-4d79-aacc-3e61f6ff5b0e"), new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), new Guid("bb03b2c7-ca1a-4bfa-bced-a398b9dab90f"), new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"), null },
                    { new Guid("72560a5e-8839-4255-a8bd-3c6c0bc9ceff"), new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), new Guid("24c523fc-7f04-40b2-9496-25d085de0584"), new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"), null },
                    { new Guid("d14b456a-5a8b-48f2-91cc-0e72367abbf9"), new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), new Guid("b44283ae-a373-4365-b424-7cf6c6e460cd"), new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"), null },
                    { new Guid("f8e75076-4a24-4b59-b0ac-3a0623144d0e"), new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), new Guid("9e28f3da-c04d-4779-8541-f58dbf0dabe9"), new Guid("9fba56d6-92c7-45b3-a9cb-11f9f861fa25"), null },
                    { new Guid("93a51970-c1bf-4d95-941b-fc46f7de5238"), new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0"), new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"), null },
                    { new Guid("4c679964-f1a0-44b3-8d11-fe2f95611d04"), new Guid("29f56b6d-9026-4e5c-a6d5-71ce24a352aa"), new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b"), new Guid("a950ca74-0487-46a6-a385-192a6dbb14fd"), null },
                    { new Guid("a20d1f13-8ad5-4658-a6db-534344a5e51e"), new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"), new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0"), new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"), null },
                    { new Guid("faef8963-cac2-4794-a4b2-67d419fd7bb1"), new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"), new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b"), new Guid("8075e73a-02ae-4b87-b613-cf6d52609e1b"), null },
                    { new Guid("a386c489-67ef-4810-8316-c8bf9a639bfa"), new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"), new Guid("23a7b943-5e4c-4304-a3ab-1cda0f58a2a0"), new Guid("0b253034-363c-4773-a2f4-580a64ac8314"), null },
                    { new Guid("e65e4461-8d9e-4c8a-8018-5f96add29c4a"), new Guid("7342bdb2-ba06-4878-a95f-6ac3fac46dbf"), new Guid("e34e7df7-31e1-422e-afb9-a7602c18567b"), new Guid("0b253034-363c-4773-a2f4-580a64ac8314"), null }
                });
        }
    }
}
