using Shop_API.Repositories.Interface;

namespace Shop_API.Context
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        ApplicationDbContext GetContext();
        int GetMySequence(String seqName);

        IStaffRepository StaffRepo { get; }
        IGroupRepository GroupRepo { get; }
        IGroupStaffRepository GroupStaffRepo { get; }
        IRoleRepository RoleRepo { get; }
        IFunctionRepository FunctionRepo { get; }
        IColorRepository ColorRepo { get; }
        IStorageRepository StorageRepo { get; }
        IBrandRepository BrandRepo { get; }
        IProductRepository ProductRepo { get; }

    }
}
