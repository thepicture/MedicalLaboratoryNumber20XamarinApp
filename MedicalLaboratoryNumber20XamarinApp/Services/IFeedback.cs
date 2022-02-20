using System.Threading.Tasks;

namespace MedicalLaboratoryNumber20XamarinApp.Services
{
    /// <summary>
    /// Определяет методы обратной связи.
    /// </summary>
    public interface IFeedback
    {
        /// <summary>
        /// Информирует пользователя.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        Task InformAsync(string message);

        /// <summary>
        /// Предупреждает пользователя.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        Task WarnAsync(string message);

        /// <summary>
        /// Запрашивает подтверждение пользователя.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <returns></returns>
        Task<bool> AskAsync(string message);

        /// <summary>
        /// Информирует об ошибке пользователя.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        Task InformErrorAsync(string message);
    }
}
