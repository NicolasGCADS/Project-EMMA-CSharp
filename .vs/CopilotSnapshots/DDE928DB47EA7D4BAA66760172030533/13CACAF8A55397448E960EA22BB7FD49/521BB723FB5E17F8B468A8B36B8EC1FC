using EMMAData;
using EMMAModel;
using System;

namespace EMMABusiness
{
    public class ReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        
        public List<Review> ListarTodos() =>
            _context.Reviews.ToList();

        
        public Review? ObterPorId(int id) =>
            _context.Reviews.Find(id);

        
        public Review Criar(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return review;
        }

        public bool Atualizar(Review review)
        {
            var existente = _context.Reviews.Find(review.IdReading);
            if (existente == null) return false;

            existente.Description = review.Description;

            _context.SaveChanges();
            return true;
        }

        
        public bool Remover(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return true;
        }
    }
}
