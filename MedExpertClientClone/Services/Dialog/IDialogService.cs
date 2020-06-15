using System;
using System.Threading.Tasks;

namespace MedExpertClientClone.Services.Dialog
{
    public interface IDialogService
    {
        /// <summary>
        /// Представляет диалоговое окно предупреждения пользователю с кнопкой отмены
        /// </summary>
        /// <param name="title">Заголовок диалогового окна</param>
        /// <param name="message">Основной текст диалогового окна</param>
        /// <param name="cancel">Текст для отображения на кнопке «Отмена»</param>
        /// <param name="destruction">Текст для отображения  на кнопке «Destruct»</param>
        /// <param name="buttons">Заголовки для дополнительных кнопок</param>
        /// <returns>Диалоговое окно предупреждения пользователю с кнопкой отмены</returns>
        Task DisplayActionSheet(string title, string cancel, string destruction, string[] buttons);
    }
}
