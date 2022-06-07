using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Abstract
{
    public interface IFileHelper
    {
        IResult Add(IFormFile  formfile);
        IResult Update(IFormFile formFile, string FilePath);
        IResult Delete(string filePath);
    }
}
