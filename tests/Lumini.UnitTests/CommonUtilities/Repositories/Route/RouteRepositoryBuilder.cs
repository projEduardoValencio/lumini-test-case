using Lumini.Domain.Interfaces.Repositories;
using Moq;

namespace Lumini.UnitTests.CommonUtilities.Repositories.Route;

public class RouteRepositoryBuilder
{
    private readonly Mock<IRouteRepository> _repository;
    
    public RouteRepositoryBuilder()
    {
        _repository = new Mock<IRouteRepository>();
    }
    
    public void GetAllInitialData(List<Lumini.Domain.Entities.Route> routes)
    {
        _repository.Setup(repo => repo.GetAll()).ReturnsAsync(routes);
    }
    
    public IRouteRepository Build()
    {
        return _repository.Object;
    }
}