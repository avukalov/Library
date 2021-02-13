using AutoMapper;
using Library.Common.Logging;
using Library.Models.DTOs.Author;
using Library.DAL.Entities;
using Library.Models.Utilities;
using Library.Repository.Common;
using Library.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ISqlRepository _sqlRepo;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger, ISqlRepository sqlRepo)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _sqlRepo = sqlRepo;
        }

        public async Task<ServiceResponse<AuthorDto>> CreateAuthorAsync(AuthorForCreationDto author)
        {
            ServiceResponse<AuthorDto> response = new ServiceResponse<AuthorDto>();

            try
            {
                var authorEntity = _mapper.Map<AuthorEntity>(author);

                //_unitOfWork.Author.CreateAuthor(authorEntity);
                //await _unitOfWork.SaveAsync();
                await _sqlRepo.CreateAuthorAsync(authorEntity);

                response.Data = _mapper.Map<AuthorDto>(authorEntity);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }
        public async Task<ServiceResponse<AuthorDto>> UpdateAuthorAsync(Guid id, AuthorForUpdateDto authorUpdate)
        {
            ServiceResponse<AuthorDto> response = new ServiceResponse<AuthorDto>();

            try
            {
                var author = await _unitOfWork.Author.GetAuthorByIdAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Author with id: {id} not found");
                }

                _mapper.Map(authorUpdate, author);

                //_unitOfWork.Author.UpdateAuthor(author);
                //await _unitOfWork.SaveAsync();
                await _sqlRepo.UpdateAuthorAsync(author);

                _logger.LogInfo($"Author with id: {author.AuthorId} successfuly updated");

                response.Data = _mapper.Map<AuthorDto>(author);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<AuthorDto>> DeleteAuthorAsync(Guid id)
        {
            ServiceResponse<AuthorDto> response = new ServiceResponse<AuthorDto>();

            try
            {
                //var author = await _unitOfWork.Author.GetAuthorByIdAsync(id);

                //if (author == null)
                //{
                //    response.Success = false;
                //    response.Message = "NotFound";

                //    _logger.LogError($"Author with id: {id} not found");
                //}

                //_unitOfWork.Author.DeleteAuthor(author);
                //await _unitOfWork.SaveAsync();

                var result = await _sqlRepo.DeleteAuthorAsync(id);
                if (!result)
                {
                    response.Success = false;
                }

                _logger.LogInfo($"Author with id: {id} successfuly deleted");
                
                //response.Data = _mapper.Map<AuthorDto>(author);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public async Task<ServiceResponse<AuthorDto>> GetAuthorByIdAsync(Guid id)
        {
            ServiceResponse<AuthorDto> response = new ServiceResponse<AuthorDto>();

            try
            {
                var author = await _sqlRepo.GetAuthorByIdAsync(id);
                //var author = await _unitOfWork.Author.GetAuthorByIdAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Author with id: {id} not found");
                }

                _logger.LogInfo($"Author with id: {id} found");

                response.Data = _mapper.Map<AuthorDto>(author);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<AuthorDto>>> GetAuthorsAsync()
        {
            ServiceResponse<IEnumerable<AuthorDto>> response = new ServiceResponse<IEnumerable<AuthorDto>>();

            try
            {
                //var authors = await _unitOfWork.Author.GetAuthorsAsync();
                var authors = await _sqlRepo.GetAuthorsAsync();

                if (authors == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Authors not found");
                }

                _logger.LogInfo($"All authors retrived");

                response.Data = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<AuthorWithBooksDto>> GetAuthorWithBooksAsync(Guid id)
        {
            ServiceResponse<AuthorWithBooksDto> response = new ServiceResponse<AuthorWithBooksDto>();

            try
            {
                var author = await _unitOfWork.Author.GetAuthorWithBooksAsync(id);

                if (author == null)
                {
                    response.Success = false;
                    response.Message = "NotFound";

                    _logger.LogError($"Author with id: {id} not found");
                }

                _logger.LogInfo($"Author with id: {id} found");

                response.Data = _mapper.Map<AuthorWithBooksDto>(author);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

    }
}
