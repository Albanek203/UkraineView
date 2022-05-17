using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;

namespace DLL.Repository;

public class ImageRepository : BaseRepository<Image> {
    public ImageRepository(UkraineContext context) : base(context) { }
}