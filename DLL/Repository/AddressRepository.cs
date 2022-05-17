using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;

namespace DLL.Repository;

public class AddressRepository : BaseRepository<Address> {
    public AddressRepository(UkraineContext context) : base(context) { }
}