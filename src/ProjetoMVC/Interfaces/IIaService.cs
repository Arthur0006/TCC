using TravelMakerII.Contracts;
using TravelMakerII.Models;

namespace TravelMakerII.Interfaces
{
    public interface IIaService
    {   
        List<MecanicSolutionModel> GetMecanic(ProblemsRequestModel request);
    }
}