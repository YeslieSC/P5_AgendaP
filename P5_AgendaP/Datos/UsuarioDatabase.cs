using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P5_AgendaP.Modelos;

namespace P5_AgendaP.Datos
{
    public class UsuarioDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public UsuarioDatabase()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            return _db.InsertAsync(usuario);
        }

        public Task<Usuario> GetUsuarioPorEmailAsync(string email)
        {
            return _db.Table<Usuario>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<Usuario> GetUsuarioPorEmailYPasswordAsync(string email, string password)
        {
            return _db.Table<Usuario>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }

}