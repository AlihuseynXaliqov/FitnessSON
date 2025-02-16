using FitnessApp.Core;
using FitnessApp.Core.FeedBack;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class ClientRepository:Repository<ClientFeedBack>,IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }
}