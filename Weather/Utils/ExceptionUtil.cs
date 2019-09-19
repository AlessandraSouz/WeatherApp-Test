using Acr.UserDialogs;
using System;

namespace Weather.Utils
{
    public class ExceptionUtil
    {
        public static async void HandleException(Exception ex)
        {
            await UserDialogs.Instance.AlertAsync($"Ocorreu um erro:\n{ex.Message}", "Erro!", "Ok!");
        }
    }
}