using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class FileService
    {
        private TextFileDBRepository tr;
        public FileService(TextFileDBRepository _textFileDBRepository)
        {
            tr = _textFileDBRepository;
        }

    }
}
