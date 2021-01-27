using System;
using System.Collections.Generic;


namespace BkServer.Dtos
{
    public class PagedResultDto<TEntity> :PageSortedAndFilterInput
    {
        public int TotalCount{set;get;}
        public int TotalPages =>(int)Math.Ceiling(decimal.Divide(TotalCount,MaxResultCount));

        public List<TEntity> Data{set;get;}

        //是否顯示上一頁
        public bool ShowPrevious => CurrentPage>1;
        //是否顯示下一頁
        public bool ShowNext => CurrentPage < TotalPages;

        //是否為第一頁
        public bool ShowFirst =>CurrentPage!=1;

        //是否為最後一頁
        public bool ShowLast => CurrentPage!= TotalPages;
    }
}