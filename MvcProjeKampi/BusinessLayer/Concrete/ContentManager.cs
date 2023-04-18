﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            var list = _contentDal.List(x=>x.ContentValue.Contains(p)).OrderByDescending(x => x.ContentDate);
            return list.ToList();
        }


        public List<Content> GetListByHeadingID(int id)
        {
           var list =  _contentDal.List(x => x.HeadingID == id).OrderBy(x => x.ContentDate);
            //var islem = db.stok_hareket.OrderByDescending(p => p.islemTarih == hareket.islemTarih).ToList();
            return list.ToList();
        }

        public List<Content> GetListByID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }
    }
}
