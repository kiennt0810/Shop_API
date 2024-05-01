using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop_API.Repositories;
using Shop_API.Repositories.Interface;

namespace Shop_API.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IStaffRepository _staffRepo;
        private IGroupRepository _groupRepo;
        private IGroupStaffRepository _groupStaffRepo;
        private IRoleRepository _roleRepo;
        private IFunctionRepository _functionRepo;
        private IColorRepository _colorRepo;
        private IStorageRepository _storageRepo;
        private IBrandRepository _brandRepo;
        private IProductRepository _productRepo;
        private ICustomerRepository _customerRepo;
        private IOrderDtlRepository _orderDtlRepo;
        private IOrderHdrRepository _orderHdrRepo;
        private IAdFileRepository _adFileRepo;
        private IProFileImgRepository _proFileImgRepo;

        public IProFileImgRepository ProFileImgRepo
        {
            get
            {
                _proFileImgRepo ??= new ProFileImgRepository(_context);
                return _proFileImgRepo;
            }
        }

        public IAdFileRepository AdFileRepo
        {
            get
            {
                _adFileRepo ??= new AdFileRepository(_context);
                return _adFileRepo;
            }
        }
        public IOrderDtlRepository OrderDtlRepo
        {
            get
            {
                _orderDtlRepo ??= new OrderDtlRepository(_context);
                return _orderDtlRepo;
            }
        }

        public IOrderHdrRepository OrderHdrRepo
        {
            get
            {
                _orderHdrRepo ??= new OrderHdrRepository(_context);
                return _orderHdrRepo;
            }
        }

        public ICustomerRepository CustomerRepo
        {
            get 
            {
                _customerRepo ??= new CustomerRepository(_context);
                return _customerRepo; 
            }
        }

        public IProductRepository ProductRepo
        {
            get
            {
                _productRepo ??= new ProductRepository(_context);

                return _productRepo;
            }
        }

        public IBrandRepository BrandRepo
        {
            get
            {
                _brandRepo ??= new BrandRepository(_context);

                return _brandRepo;
            }
        }

        public IColorRepository ColorRepo
        {
            get
            {
                _colorRepo ??= new ColorRepository(_context);

                return _colorRepo;
            }
        }

        public IStorageRepository StorageRepo
        {
            get
            {
                _storageRepo ??= new StorageCapacitiesRepository(_context);

                return _storageRepo;
            }
        }

        public IStaffRepository StaffRepo
        {
            get
            {
                _staffRepo ??= new StaffRepository(_context);

                return _staffRepo;
            }
        }
        public IGroupRepository GroupRepo
        {
            get
            {
                _groupRepo ??= new GroupRepository(_context);

                return GroupRepo;
            }
        }
        public IGroupStaffRepository GroupStaffRepo
        {
            get
            {
                _groupStaffRepo ??= new GroupStaffRepository(_context);

                return _groupStaffRepo;
            }
        }

        public IRoleRepository RoleRepo
        {
            get
            {
                _roleRepo ??= new RoleRepository(_context);

                return _roleRepo;
            }
        }

        public IFunctionRepository FunctionRepo
        {
            get
            {
                _functionRepo ??= new FunctionRepository(_context);

                return _functionRepo;
            }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public ApplicationDbContext GetContext()
        {
            return _context;
        }
        public int GetMySequence(String seqName)
        {
            var p = new SqlParameter("@result", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.Output;
            _context.Database.ExecuteSqlRaw("set @result = next value for " + seqName, p);
            var nextVal = (int)p.Value;
            return nextVal;
        }
    }
}
