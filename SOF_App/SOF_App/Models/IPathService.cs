using System;
using System.Collections.Generic;
using System.Text;

namespace SOF_App.Models
{
    public interface IPathService
    {
        string InternalFolder { get; }
        string PublicExternalFolder { get; }
        string PrivateExternalFolder { get; }
        void OpenPdfFile(string FileName);
        void CheckDir(String Path);
    }
}
