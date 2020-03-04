using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;
using Cv_Generator_Server.Models.DTOs.Response;
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
        /// <param name="data">informacion de datos academico</param>
        public Academic Add(AcademicAddDTO data)
        {
            Academic academic = new Academic()
            {
                Degree = data.Degree,
                UserId = data.UserId,
                Type = data.Type,
                Start_Date = data.Start_Date,
                End_Date = data.End_Date,
                Institution = data.Institution,
                State = 1,
            };
            try
            {
                _context.academics.Add(academic);
                _context.SaveChanges();
                return academic;
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
        public async Task<ResponseAcademicDTO> Get(int id)
        {
            var academic = await _context.academics.FindAsync(id);
            return new ResponseAcademicDTO()
            {
                Type = academic.Type,
                AcademicId = academic.AcademicId,
                Institution = academic.Institution,
                Degree = academic.Degree,
                End_Date = academic.End_Date,
                Start_Date = academic.Start_Date
            };
        }

        /// <summary>
        /// Obtiene todos los datos academico
        /// </summary>
        /// <returns>retorna un listado de datos academico</returns>
        public List<ResponseAcademicDTO> GetAcademicsData()
        {
            var academics = _context.academics.Where(x => x.State == 1).ToList();
            List<ResponseAcademicDTO> academicDTOs = new List<ResponseAcademicDTO>();
            foreach(var dto in academics)
            {
                academicDTOs.Add(new ResponseAcademicDTO()
                {
                    AcademicId = dto.AcademicId,
                    Degree = dto.Degree,
                    End_Date = dto.End_Date,
                    Institution = dto.Institution,
                    Start_Date = dto.Start_Date,
                    Type = dto.Type
                });
            }
            return academicDTOs;
        }

        /// <summary>
        /// Actualiza un dato academico
        /// </summary>
        /// <param name="data">informacion del datos academico a actualizar</param>
        public void Update(AcademicUpdateDTO data)
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
