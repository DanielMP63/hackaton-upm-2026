using Hackathon1.Data;
using Hackathon1.Models;

namespace Hackathon1.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ApplicationDbContext _context;

        public WeatherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WeatherDto> GetForecastAsync(string provincia)
        {
            if (string.IsNullOrWhiteSpace(provincia))
                throw new ArgumentException("La provincia no puede estar vacía.", nameof(provincia));

            var fecha = DateTime.UtcNow.Date;

            var dto = new WeatherDto
            {
                Indicativo = "3195",
                Nombre = provincia,
                Provincia = provincia,
                Fecha = fecha,
                HoraTmax = "15:00",
                HoraTmin = "07:00",
                HoraHrMax = "08:00",
                HoraHrMin = "15:30",
                Tmax = "28.4",
                Tmin = "14.2",
                Tmed = "21.3",
                Prec = "0.0",
                HrMax = 85,
                HrMin = 42,
                HrMedia = 63,
                Racha = "35.2",
                Horaracha = "13:20",
                Velmedia = "18.5",
                PresMax = "1018.6",
                PresMin = "1012.3",
                HoraPresMax = "09:00",
                HoraPresMin = "18:00",
                Altitud = 667,
                Sol = "9.8",
                Dir = "SE"
            };

            var record = new WeatherRecord
            {
                Indicativo = dto.Indicativo,
                Nombre = dto.Nombre,
                Provincia = dto.Provincia,
                Fecha = dto.Fecha,
                HoraTmax = dto.HoraTmax,
                HoraTmin = dto.HoraTmin,
                HoraHrMax = dto.HoraHrMax,
                HoraHrMin = dto.HoraHrMin,
                Tmax = dto.Tmax,
                Tmin = dto.Tmin,
                Tmed = dto.Tmed,
                Prec = dto.Prec,
                HrMax = dto.HrMax,
                HrMin = dto.HrMin,
                HrMedia = dto.HrMedia,
                Racha = dto.Racha,
                Horaracha = dto.Horaracha,
                Velmedia = dto.Velmedia,
                PresMax = dto.PresMax,
                PresMin = dto.PresMin,
                HoraPresMax = dto.HoraPresMax,
                HoraPresMin = dto.HoraPresMin,
                Altitud = dto.Altitud,
                Sol = dto.Sol,
                Dir = dto.Dir
            };

            _context.WeatherRecords.Add(record);
            await _context.SaveChangesAsync();

            return dto;
        }
    }
}
