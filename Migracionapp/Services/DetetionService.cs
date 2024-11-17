using System.Drawing;
using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Data.Sqlite;
using Migracionapp.Models;

public class DetentionService
{
    public List<CalendarEvent> GetDetentionAsEvents()

    {
        List <CalendarEvent> events = new List <CalendarEvent>();
        
        using (var connection = new SqliteConnection("Data Source=detenidos.db"))
        {
            connection.Open();
            string query = "Select Id, NombreCompleto, FechaDetencion, NumeroPasaporte FROM detenidos";
            using (var command = new SqliteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    events.Add(new CalendarEvent{
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = $"Detenido el {reader.GetDateTime(2):dd/MM/yyyy} con pasaporte numero: {reader.GetString(3)}",
                        StartDate = reader.GetDateTime(2),
                        EndDate = reader.GetDateTime(2),
                        Color = "#FF0000"

                    });
                }
            }
        }

        return events;
    }

  
}