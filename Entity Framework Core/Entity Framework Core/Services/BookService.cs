using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entity_Framework_Core.DataContext;
using Entity_Framework_Core.Models;
namespace Entity_Framework_Core.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService() => _context = App.GetContext();

        public List<Book> Get()
        {
            return _context.Books.ToList();
        }

        public Book GetByTitulo(string Titulo)
        {
            return _context.Books.Where(x => x.Titulo == Titulo).FirstOrDefault();
        }


        public Book GetByID(int ID)
        {
            return _context.Books.Where(x => x.BookID == ID).FirstOrDefault();
        }
        public bool Create(Book item)
        {
            try
            {
                _context.Books.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public void Update(Book item, int ID)
        {
            var model = GetByID(ID);
            model.Author = item.Author;
            model.Precio = item.Precio;
            model.Titulo = item.Titulo;
            model.Fecha = item.Fecha;
            model.Disponible = item.Disponible;
            
            _context.SaveChanges();
        }
        public void Delete(int ID)
        {
            var model = GetByID(ID);
            _context.Remove(model);
            _context.SaveChanges();
        }
    }

}

