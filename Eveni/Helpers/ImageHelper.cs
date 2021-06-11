using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers.Interfaces;

namespace Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        private const string cloudName = "ramsayimg";
        private const string apiKey = "982947359594978";
        private const string apiSecret = "YApm_oCt_NFym-D4m2Ye7hRrSAM";

        private readonly Cloudinary _cloudinary;
        public ImageHelper()
        {
            Account account = new Account(cloudName,apiKey,apiSecret);
            _cloudinary = new Cloudinary(account);
        }

        [Obsolete]
        public string ImageUpload(Stream stream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), stream)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.SecureUri.AbsoluteUri;
        }
    }
}
