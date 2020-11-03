using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlogFitness.BL.Controller
{
    public interface IDataSaver
    {
        void Save(string fileName, object item);
        T Load<T>(string fileName);
    }
}
