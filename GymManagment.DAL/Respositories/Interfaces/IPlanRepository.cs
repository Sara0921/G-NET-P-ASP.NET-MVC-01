using Gym_Mvc_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Respositories.Interfaces
{
    public interface IPlanRepository
    {
        //GetAllPlan
        Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false , CancellationToken ct= default);
        //GetPlanById
        Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default);
        //Add
        Task<int> AddAsync(Plan plan, CancellationToken ct = default);
        //Update
        Task<int> UpdateAsync(Plan plan, CancellationToken ct = default);
        //Delete
        Task<int> DeleteAsync(Plan plan, CancellationToken ct = default);

    }
}
