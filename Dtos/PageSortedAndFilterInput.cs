using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BkServer.Models;

namespace BkServer.Dtos
{
    public class PageSortedAndFilterInput
    {
        public PageSortedAndFilterInput()
        {
            CurrentPage=1;
            MaxResultCount=10;
        }
        //每頁分頁列數
        [Range(0,250)]
        public int MaxResultCount{set;get;}
        
        // 當前頁
        public int CurrentPage{set;get;} =1;

        ///排序字
        public string Sorting{set;get;}
        //查詢名稱
        public string FilterText{set;get;}
    }

}