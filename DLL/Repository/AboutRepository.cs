using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;

namespace DLL.Repository;

public class AboutRepository : BaseRepository<About> {
    public AboutRepository(UkraineContext context) : base(context) { }
}