using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        //Geral
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();

        //Alunos
        Task<Aluno[]> GetAllAlunosAsync(bool incluirProfessor);
        Task<Aluno> GetAlunoByIdAsync(int alunoId, bool incluirProfessor);
        Task<Aluno[]> GetAlunoByProfessorIdAsync(int professorId, bool incluirProfessor);

        //Professor
        Task<Professor[]> GetAllProfessorsAsync(bool incluirAluno);
        Task<Professor> GetProfessorByIdAsync(int professorId, bool incluirAluno);
    }
}