namespace BkServer.Dtos
{
    public class GetCloudAccountInput:PageSortedAndFilterInput
    {
        public GetCloudAccountInput()
        {
            Sorting="";
        }
    }
     public class GetUserInput:PageSortedAndFilterInput
    {
        public GetUserInput()
        {
            Sorting="";
        }
    }
    public class GetLogInput:PageSortedAndFilterInput
    {
        public string Id{set;get;}
        public GetLogInput()
        {
            
            Sorting="";
        }
    }
}