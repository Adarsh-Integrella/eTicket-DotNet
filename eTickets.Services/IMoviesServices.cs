
using eTickets.Base;
using eTickets.Data;
using eTickets.Models;

namespace eTickets.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownVM> GetNewMovieDropDownValues();
        Task AddNewMovieAsync (NewMovieVM data);
        Task UpdateMovieAsync (NewMovieVM data);

    }
}