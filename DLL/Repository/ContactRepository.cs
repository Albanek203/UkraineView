using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;

namespace DLL.Repository;

public class ContactRepository : BaseRepository<Contact> {
    public ContactRepository(UkraineContext context) : base(context) { }
}