using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers.Interfaces
{
    public interface IImageHelper
    {
        string ImageUpload(Stream stream);
    }
}
