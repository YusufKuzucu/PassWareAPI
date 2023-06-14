using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FilesManager : IFilesService
    {
        IFilesDal _filesDal;
        public FilesManager(IFilesDal filesDal)
        {
           _filesDal = filesDal;    
        }
        public async Task<IResult> AddFiles(Files files, string createdBy)
        {
            await _filesDal.AddAsync(files, createdBy);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteFiles(int id)
        {
            await _filesDal.DeleteAsync(id);
            return new SuccessResult();

        }

        public async Task<IDataResult<List<Files>>> GetAllFiles()
        {
            return new SuccessDataResult<List<Files>>(await _filesDal.GetAllAsync());
        }

        public async Task<IDataResult<List<Files>>> GetByFiles(int id)
        {
            return new SuccessDataResult<List<Files>>(await _filesDal.GetAllAsync(x=>x.ProjectId==id));
        }

        public async Task<IDataResult<byte[]>> GetFile(int id)
        {
            var file = await _filesDal.GetAsync(x => x.ProjectId == id);
            if (file != null && file.ConnectionInfo != null)
            {
                return new SuccessDataResult<byte[]>(file.ConnectionInfo);
            }
            return new ErrorDataResult<byte[]>("Dosya bulunamadı.");
        }

        public async Task<IDataResult<Files>> GetFiles(int id)
        {
            return new SuccessDataResult<Files>(await _filesDal.GetAsync(p => p.Id == id));
        }

        public async Task<IResult> UpdateFiles(Files files, string updatedBy)
        {
            await _filesDal.UpdateAsync(files, updatedBy);
            return new SuccessResult();
        }
    }
}
