using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelA.WebUI.Models
{
    public class ViewModelBase<E, F>
    {
        private PagingInfo _pagingInfo = null;
        private IEnumerable<E> _entity = null;

        public IEnumerable<E> Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
            }
        }

        public F Filter { get; set; }

        public PagingInfo PagingInfo
        {
            get
            {
                if (_pagingInfo == null)
                {
                    _pagingInfo = new PagingInfo
                    {
                        CurrentPage = 1,
                        ItemsPerPage = 5,
                        TotalItems = 0
                    };
                }

                return _pagingInfo;
            }
            set
            {
                _pagingInfo = value;
            }
        }

        public void Paging(int page = 1)
        {
            if (Entity != null)
            {
                PagingInfo.CurrentPage = page;
                PagingInfo.TotalItems = Entity.Count();
                Entity = Entity.Skip((page - 1) * PagingInfo.ItemsPerPage).Take(PagingInfo.ItemsPerPage);
            }
        }
    }
}