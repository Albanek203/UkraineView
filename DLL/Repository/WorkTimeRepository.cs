using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;

namespace DLL.Repository;

public class WorkTimeRepository : BaseRepository<WorkTime> {
    public WorkTimeRepository(UkraineContext context) : base(context) { }
}