using EMMAData;
using EMMAModel;
using System;

namespace EMMABusiness
{
    public class ReadingService
    {
        private readonly AppDbContext _context;

        public ReadingService(AppDbContext context)
        {
            _context = context;
        }

        public List<Reading> ListarTodos() =>
            _context.Readings.ToList();

        public Reading? ObterPorId(int id) =>
            _context.Readings.Find(id);

        public Reading Criar(Reading reading)
        {
            _context.Readings.Add(reading);
            _context.SaveChanges();
            return reading;
        }

        public bool Atualizar(Reading reading)
        {
            var existente = _context.Readings.Find(reading.IdReading);
            if (existente == null) return false;

            existente.CreationDate = reading.CreationDate;
            existente.Description = reading.Description;
            existente.Humor = reading.Humor;

            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var reading = _context.Readings.Find(id);
            if (reading == null) return false;

            _context.Readings.Remove(reading);
            _context.SaveChanges();
            return true;
        }
    }
}
