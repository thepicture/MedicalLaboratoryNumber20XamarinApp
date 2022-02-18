using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    /// <summary>
    /// Определяет хранилище, основанное на API.
    /// </summary>
    /// <typeparam name="TResponseBody">Тип тела ответа.</typeparam>
    public interface IDataStoreService<TResponseBody>
    {
        /// <summary>
        /// Создаёт ресурс.
        /// </summary>
        /// <param name="body">Тело запроса.</param>
        /// <returns><see langword="true"/>, если сущность опубликована, 
        /// иначе <see langword="false"/>.</returns>
        Task<bool> CreateAsync<TRequestBody>(TRequestBody body);

        /// <summary>
        /// Получает объект <typeparamref name="TResponseBody"/> 
        /// на основе заданного идентификатора.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Объект типа <typeparamref name="TResponseBody"/>, 
        /// если сущность найдена, иначе <see langword="null"></see>.</returns>
        Task<TResponseBody> ReadSingleAsync(string id);

        /// <summary>
        /// Получает все объекты <typeparamref name="TResponseBody"/>.
        /// </summary>
        /// <returns>Все объекты <typeparamref name="TResponseBody"/>.</returns>
        Task<IEnumerable<TResponseBody>> ReadAllAsync();

        /// <summary>
        /// Обновляет ресурс.
        /// </summary>
        /// <param name="id">Идентификатор ресурса.</param>
        /// <param name="body">Тело запроса.</param>
        /// <returns></returns>
        Task<bool> UpdateAsync<TRequestBody>(string id, TRequestBody body);
    }
}
