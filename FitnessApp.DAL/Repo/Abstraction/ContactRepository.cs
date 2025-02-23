using FitnessApp.Core.Contact;
using FitnessApp.DAL.Repo.Interface;

namespace FitnessApp.DAL.Repo.Abstraction;

public class ContactRepository:Repository<ContactMessage>,IContactRepository
{
    public ContactRepository(AppDbContext context) : base(context)
    {
    }
}