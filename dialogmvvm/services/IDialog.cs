using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace dialogmvvm.services
{
    public interface IDialog
    {
        object DataContext { get; set; }
        bool? DialogResult { get; set; }
        Window owner { get; set; }
        void Close();
        bool? ShowDialog();
    }

    public interface IDialogService
    {
        void Register<TViewModel, TView>() where TViewModel : IDialogRequestClose
                                           where TView : IDialog;
        bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose;
    }


    public interface IDialogRequestClose
    {
        event EventHandler<DialogCloseRequestedArgs> CloseRequested;
    }

    public class DialogCloseRequestedArgs : EventArgs
    {
        public DialogCloseRequestedArgs(bool? dialogResult)
        {
            dialogResult = dialogResult;
        }
        public bool? DialogResult { get; }
    }



    public class DialogService : IDialogService
    {
        private Window owner;
        public IDictionary<Type, Type> Mappings { get; set; }

        public DialogService(Window owner)
        {
            this.owner = owner;
            Mappings = new Dictionary<Type, Type>();
        }

        public void Register<TViewModel, TView>()
            where TViewModel : IDialogRequestClose
            where TView : IDialog
        {
            if (Mappings.ContainsKey(typeof(TViewModel)))
            {
                throw new ArgumentException($"Type {typeof(TViewModel)} is already Mapped to type {typeof(TView)}");
            }
            Mappings.Add(typeof(TViewModel), typeof(TView));
        }

        public bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose
        {
            Type viewType = Mappings[typeof(TViewModel)];
            IDialog dialog = (IDialog)Activator.CreateInstance(viewType);
            EventHandler<DialogCloseRequestedArgs> handler = null;
            handler = (sender, e) =>
            {
                viewModel.CloseRequested -= handler;
                if (e.DialogResult.HasValue)
                {
                    dialog.DialogResult = e.DialogResult;
                }
                else
                {
                    dialog.Close();
                }
            };
            viewModel.CloseRequested += handler;
            dialog.DataContext = viewModel;
            dialog.owner = owner;
            return dialog.ShowDialog();
        }
    }
}
