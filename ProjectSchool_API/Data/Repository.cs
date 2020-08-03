using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            try
            {
                _context.Add(entity);
            }
            catch (System.Exception err)
            {
                throw err;
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        //Aluno
        public async Task<Aluno[]> GetAllAlunosAsync(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query =  _context.Alunos;

            if(incluirProfessor){
                query = query.Include(profs => profs.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(aluno => aluno.Id);

            return (await query.ToArrayAsync());
        }

        public async Task<Aluno> GetAlunoByIdAsync(int alunoId, bool incluirProfessor)
        {
            IQueryable<Aluno> query =  _context.Alunos;

            if(incluirProfessor){
                query = query.Include(profs => profs.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.Id == alunoId);

            return (await query.FirstOrDefaultAsync());
        }

        public async Task<Aluno[]> GetAlunoByProfessorIdAsync(int professorId, bool incluirProfessor)
        {
            IQueryable<Aluno> query =  _context.Alunos;

            if(incluirProfessor){
                query = query.Include(profs => profs.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.ProfessorId == professorId);

            return (await query.ToArrayAsync());
        }

        //Professor
        public async Task<Professor[]> GetAllProfessorsAsync(bool incluirAluno = false)
        {
            IQueryable<Professor> query =  _context.Professores;

            if(incluirAluno){
                query = query.Include(a => a.Alunos);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(Professor => Professor.Id);

            return (await query.ToArrayAsync());
        }

        public async Task<Professor> GetProfessorByIdAsync(int professorId, bool incluirAluno = false)
        {
            IQueryable<Professor> query =  _context.Professores;

            if(incluirAluno){
                query = query.Include(a => a.Alunos);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(Professor => Professor.Id)
                        .Where(Professor => Professor.Id == professorId);

            return (await query.FirstOrDefaultAsync());
        }
    }
}