using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Services
{
    /// <summary>
    /// Servicio para resolver request de la entidad Academic
    /// </summary>
    public class AcademicService : IAcademicService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AcademicService(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Agrega un dato academico
        /// </summary>
        /// <param name="academic">informacion de datos academico</param>
        public void Add(Academic academic)
        {
            try
            {
                _context.academics.Add(academic);
                _context.SaveChanges();
            }catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// elimina un dato academico
        /// </summary>
        /// <param name="id">id del dato academico a eliminar</param>
        public void Delete(int id)
        {
            try
            {
                var data = _context.academics.Single(x => x.AcademicId == id);
                data.State = -1;
                _context.Update(data);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un dato academico
        /// </summary>
        /// <param name="id">id del dato</param>
        /// <returns>retorna el dato academico solicitado</returns>
        public async Task<Academic> Get(int id)
        {
            return await _context.academics.FindAsync(id);
        }

        /// <summary>
        /// Obtiene todos los datos academico
        /// </summary>
        /// <returns>retorna un listado de datos academico</returns>
        public List<Academic> GetAcademicsData()
        {
            return _context.academics.Where(x => x.State == 1).ToList();
        }

        /// <summary>
        /// Actualiza un dato academico
        /// </summary>
        /// <param name="data">informacion del datos academico a actualizar</param>
        public void Update(Academic data)
        {
            try
            {
                var dataOriginal = _context.academics.Single(x => x.AcademicId == data.AcademicId);
                dataOriginal.Degree = data.Degree;
                dataOriginal.Start_Date = data.Start_Date;
                dataOriginal.End_Date = data.End_Date;
                dataOriginal.Institution = data.Institution;
                _context.Update(dataOriginal);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
