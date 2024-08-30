using Command._02_Extension;
using Command._04_BizDomain.Common.Error;
using System;
using System.Collections.Generic;

namespace CommandThird._01_Command
{
    public interface ICommand
    {   
        void Execute();
    }

    public abstract class BaseCommand<T> : ICommand
    {
        public T Output {  get; set; }  
        public List<ErrorItem> Errors = new List<ErrorItem>();
 
        protected virtual void Init()
        {

        }

        protected virtual bool CanExecute()
        {
            return true;
        }

        protected virtual bool OnExcuting()
        {
            return true;
        }

        protected abstract void ExecuteCore();

        protected virtual bool Executed()
        {
            Errors.ForEach(error => Console.WriteLine($"{error.code} | {error.message}"));
            return true;
        }

        public void Execute()
        {
            if (!OnExcuting())
            {
                Errors.vAddError(new Exception("OnExcuting 에서 걸러짐"));
            }

            try {
                ExecuteCore();
            } 
            catch (Exception ex) {
                Errors.vAddError(ex);
            }

            if (!CanExecute())
            {
                Errors.vAddError(new Exception("CanExecute 에서 걸러짐"));
            }

            Executed();
        }
    }

}
