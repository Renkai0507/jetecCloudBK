using BkServer.Models;
using BkServer.Repository.Interface;
using BkServer.Repository.View.Interface;

namespace BkServer.Repository
{
    public interface IRepositoryWrapper
    {
        IAlarmlog Alarmlog{get;}
        IDeviceShow DeviceShow{get;}
        ICustMastRepository CustMast{get;}
        ICustEmailRepository CustEmail{get;}
        ICustLinekeyRepository LinekeyRepository{get;}
        IAccountRepository Account{get;}
        ICustSidRepository CustSid{get;}
        IRemotedataRepository Remotedata{get;}
        IRemotedataRecentRepository RemotedataRecent{get;}
        IProxyCompany ProxyCompany{get;}
    }
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IAlarmlog _Alarmlog=null;
        private IDeviceShow _DeviceShow=null;
        private IProxyCompany _ProxyCompany=null;
        private ICustMastRepository _CustMast=null;
        private ICustEmailRepository _CustEmail=null;
        private IAccountRepository _Account=null;
        private IRemotedataRecentRepository _RemotedataRecent=null;
        private IRemotedataRepository _Remotedata=null;
        private ICustLinekeyRepository _CustLineKey=null;
        private ICustSidRepository _Custsid=null;
        public jetec_join_systemContext LibraryDbContext{get;}

        public RepositoryWrapper(jetec_join_systemContext libraryDbContext)
        {
            LibraryDbContext=libraryDbContext;                      
        }
        public IAlarmlog Alarmlog =>_Alarmlog?? new AlarmlogRepository(LibraryDbContext);
        public IDeviceShow DeviceShow=>_DeviceShow?? new DeviceRepository(LibraryDbContext);
        public IProxyCompany ProxyCompany=>_ProxyCompany?? new ProxyCompanyRepository(LibraryDbContext);
        public ICustEmailRepository CustEmail => _CustEmail ?? new CustEmailRepository(LibraryDbContext) ;

        public ICustLinekeyRepository LinekeyRepository =>_CustLineKey ?? new CustLineKeyRepository(LibraryDbContext);

        public IAccountRepository Account => _Account ?? new AccountRepository(LibraryDbContext);

        public ICustSidRepository CustSid => _Custsid ?? new CustsidRepository(LibraryDbContext);

        public IRemotedataRepository Remotedata => _Remotedata ?? new RemotedataRepository(LibraryDbContext);

        public IRemotedataRecentRepository RemotedataRecent => _RemotedataRecent ?? new RemotedataRecentRepository(LibraryDbContext);

        public ICustMastRepository CustMast => _CustMast?? new CustMastRepository(LibraryDbContext);
    }
}