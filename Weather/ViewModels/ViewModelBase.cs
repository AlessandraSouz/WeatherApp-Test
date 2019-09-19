using Acr.UserDialogs;
using Weather.Utils;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Weather.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value,
                                      [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task ExecuteAsyncFunction(Func<Task> function)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando...", MaskType.Black);
                await function();
            }
            catch (Exception ex)
            {
                ExceptionUtil.HandleException(ex);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

        protected void ExecuteFunction(Action function)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Carregando...", MaskType.Black);
                function();
            }
            catch (Exception ex)
            {
                ExceptionUtil.HandleException(ex);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
    }
}