

using BkServer.Models;

namespace BkServer.Repository
{
   
     public interface IBKRepository
    {
        IUser User{get;}
        IRegUser RegUser{get;}
    }
    public class BKRepository :IBKRepository
    {
        IUser _User=null;
        IRegUser _RegUser=null;
        jetecbkContext LibraryDbContext {get;}

       
        public BKRepository(jetecbkContext libraryDbContext)
        {
             LibraryDbContext=libraryDbContext;  
        }
        public IUser User => _User ?? new UserRepository(LibraryDbContext);
        public IRegUser RegUser => _RegUser ?? new reg_UserRepository(LibraryDbContext);
    }
    
}