using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOF_App.Helper
{
   public class HelperFile
    {
        public static byte[] ReadFully(Stream input )
        {
            using(MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
