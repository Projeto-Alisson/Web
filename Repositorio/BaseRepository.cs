﻿using Microsoft.EntityFrameworkCore;
using Repositorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public class BaseRepository<T>
         : IDisposable, IBaseRepository<T> where T : class
    {
        private agendanetContext _context;


        public T get(int id)
        {
            using (_context = new agendanetContext())
            {
                return _context.Set<T>().Find(id);
            }
           
        }

        public  List<T> getAll()
        {
            using (_context = new agendanetContext())
            {
                return _context.Set<T>().ToList();
            }
            
        }

        public void add(T item)
        {
            using (_context = new agendanetContext())
            {
                _context.Set<T>().Add(item);
                _context.SaveChanges();
            }           
        }

        public void delete(T item)
        {
            using (_context = new agendanetContext())
            {
                //_context.Set<T>().Remove(item);
                _context.Entry(item).State = EntityState.Deleted;
                _context.SaveChanges();
            }

           
        }

        public void edit(T item)
        {
            using (_context = new agendanetContext())
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
           
        }

        public void Dispose()
        {
            using (_context = new agendanetContext())
            {
                _context.Dispose();
            }
           
        }
    }


    
}
