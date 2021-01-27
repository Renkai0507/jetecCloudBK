using System.Linq;
using System.Threading.Tasks;
using BkServer.Dtos;
using BkServer.Models;
using BkServer.Repository;
using BkServer.Service.Interface;

namespace BkServer.Service
{
    public class UserService : IUserService
    {
        private readonly IBKRepository Repository;

        public UserService(IBKRepository repository)
        {
            Repository=repository;
        }

        public async Task<PagedResultDto<User>> GetPaginatedResult(GetUserInput input)
        {
            var users = await Repository.User.GetAllListAsync();
            if (!string.IsNullOrEmpty(input.FilterText))
            {
                users=users.Where(X=>X.Usergroup.Contains(input.FilterText)||X.UserName.Contains(input.FilterText)||X.UserId.Contains(input.FilterText)).ToList();
            }
            var count = users.Count();

            //排序處理
            switch(input.Sorting)
            {
                case "UserId":
                    users=users.OrderBy(S=>S.UserId).ToList();                    
                    break;
                case "UserId_desc":
                    users=users.OrderByDescending(S=>S.UserId).ToList();                    
                    break;
                case "group":
                    users=users.OrderBy(S=>S.Usergroup).ToList();                    
                    break;
                case "group_desc":
                    users=users.OrderByDescending(S=>S.Usergroup).ToList();                    
                    break;
                case "type":
                    users=users.OrderBy(S=>S.UserType).ToList();                    
                    break;
                case "type_desc":
                    users=users.OrderByDescending(S=>S.UserType).ToList();                    
                    break;
                default:
                    users=users.OrderByDescending(S=>S.Allowdate).ToList();
                  
                    break;
            }
            //排序處理

            var dtos = new PagedResultDto<User>
            {
                 TotalCount=count,
                CurrentPage=input.CurrentPage,
                MaxResultCount=input.MaxResultCount,
                Data=users,
                FilterText=input.FilterText,
                Sorting =input.Sorting
            };
            return dtos;
        }
    }
}