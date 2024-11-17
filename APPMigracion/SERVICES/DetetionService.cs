using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using APPMigracion.Models;

public class DetentionService
{
    public List<CalendarEvent> GetDetentionsAsEvents()
    {
        List<CalendarEvent> events = new List<CalendarEvent>();

        using (var connection = new SqliteConnection("Data Source=detenidos.db"))
        {
            connection.Open();
            string query = "SELECT Id, NombreCompleto, FechaDetencion, NumeroPasaporte FROM detenidos";
            using (var command = new SqliteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    events.Add(new CalendarEvent
                    {
                        Id = reader.GetInt32(0), // Id del detenido
                        Title = reader.GetString(1), // Nombre completo del detenido
                        Description = $"Detenido el {reader.GetDateTime(2):dd/MM/yyyy} con pasaporte número: {reader.GetString(3)}", // Descripción con fecha de detención y número de pasaporte
                        StartDate = reader.GetDateTime(2), // Fecha de detención como fecha de inicio del evento
                        EndDate = reader.GetDateTime(2), // Fecha de detención también como fecha de fin (un solo día)
                        Color = "#FF0000" // Color del evento en el calendario (puedes ajustar esto)
                    });
                }
            }
        }

        return events;
    }
}


// using Microsoft.Data.Sqlite;
// using System.Collections.Generic;

// public class DetentionService
// {
//     public List<CalendarEvent> GetDetentionsAsEvents()
//     {
//         List<CalendarEvent> events = new List<CalendarEvent>();

//         using (var connection = new SqliteConnection("Data Source=detenidos.db"))
//         {
//             connection.Open();
//             string query = "SELECT Id, NombreCompleto, FechaDetencion, NumeroPasaporte FROM detenidos";
//             using (var command = new SqliteCommand(query, connection))
//             using (var reader = command.ExecuteReader())
//             {
//                 while (reader.Read())
//                 {
//                     events.Add(new CalendarEvent
//                     {
//                         Id = reader.GetInt32(0), // Id del detenido
//                         Title = reader.GetString(1), // Nombre completo del detenido
//                         Description = $"Detenido el {reader.GetDateTime(2):dd/MM/yyyy} con pasaporte número: {reader.GetString(3)}", // Descripción con fecha de detención y número de pasaporte
//                         StartDate = reader.GetDateTime(2), // Fecha de detención como fecha de inicio del evento
//                         EndDate = reader.GetDateTime(2) // Fecha de detención también como fecha de fin (un solo día)
//                     });
//                 }
//             }
//         }

//         return events;
//     }
// }
