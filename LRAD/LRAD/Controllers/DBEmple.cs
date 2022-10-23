using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LRAD.Controllers
{
    public class DBEmple
    {
        readonly SQLiteAsyncConnection _conexion;
        //constructor vacio
        public DBEmple()
        { } 

        //constructor parametros

        public DBEmple(string dbpath)
        {
            //creando una conexion a base de datos sqlite apartir del path de la base de datos
            _conexion = new SQLiteAsyncConnection (dbpath);

            //crear las tablas correspondientes en la bas de datos de sqlite
            _conexion.CreateTableAsync<Models.Empleados>().Wait();
        }

        // CRUD - Aplicaciones
        // create

        public Task<int> StoreEmple(Models.Empleados emple)
        {
            if (emple.Id != 0)
            {
                return _conexion.UpdateAsync(emple);
            }
            else
            {
                return _conexion.InsertAsync(emple);
            }
        }

        //Read

        public Task<List<Models.Empleados>> Listaempleados()
        {
            return _conexion.Table<Models.Empleados>().ToListAsync();
        }

        public Task<Models.Empleados> getempleado(int pid)
        {
            return _conexion.Table<Models.Empleados>()
                .Where(i => i.Id == pid)
                .FirstOrDefaultAsync();
        }
        public Task<int> Deleteempleado(Models.Empleados emple)
        {
            return _conexion.DeleteAsync(emple);
        }

    }
}
