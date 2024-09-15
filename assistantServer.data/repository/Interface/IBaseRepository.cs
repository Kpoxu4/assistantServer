using assistantServer.data.model;

namespace assistantServer.data.repository.Interface
{
    public interface IBaseRepository<DbModel> where DbModel : BaseModel
    {
        bool Any();
        DbModel Create(DbModel model);
        void Delete(DbModel model);
        void Delete(int id);
        DbModel? Get(int id);
        List<DbModel> GetAll();
    }
}
