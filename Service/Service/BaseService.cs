using Microsoft.AspNetCore.Http;
using Service.Entities;
using Service.Model.Common;
using Service.Model.ResponseModel;
using Service.Mongo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BaseService<TEntity> where TEntity : BaseModel
    {
        private readonly IMongoRepository<TEntity> repository;
        public BaseService(IMongoRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async virtual Task<ListDataOutput<TEntity>> GetAll()
        {
            var response = new ListDataOutput<TEntity>();
            try
            {
                var listData = await repository.GetAllAsync();
                response.TotalRecord = listData.Count();
                response.Data = listData.ToList();
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }

        public async Task<TEntity> GetById(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async virtual Task<Response> Insert(TEntity entity, HttpContext context)
        {
            var response = new Response();
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            entity.CreatedBy = context.Request.Headers["UserName"];
            entity.UpdatedBy = context.Request.Headers["UserName"];
            try
            {
                var count = await repository.InsertAsync(entity);
                response.StatusCode = ResponseStatusCode.Success;
                response.Id = count.Id;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }

        public async virtual Task<Response> Update(TEntity entity, HttpContext context)
        {
            var response = new Response();
            try
            {
                var collection = await repository.GetByIdAsync(entity.Id);
                if (collection == null)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.ErrorMessage = EnumMessage.NOT_FOUND.GetDescription();
                    return response;
                }
                var currentEntity = await GetById(entity.Id);
                entity.CreatedDate = currentEntity.CreatedDate;
                entity.CreatedBy = currentEntity.CreatedBy;
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = context.Request.Headers != null && context.Request.Headers.Count > 0 ? context.Request.Headers["UserName"] : "";

                var count = await repository.UpdateAsync(entity);
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }

        public async virtual Task<Response> Delete(string id)
        {
            var response = new Response();
            try
            {
                var collection = repository.GetById(id);
                if (collection == null)
                {
                    response.StatusCode = ResponseStatusCode.Error;
                    response.ErrorMessage = EnumMessage.NOT_FOUND.GetDescription();
                    return response;
                }
                await repository.DeleteAsync(id);
                response.StatusCode = ResponseStatusCode.Success;
            }
            catch (Exception ex)
            {
                response.StatusCode = ResponseStatusCode.Error;
                response.ErrorMessage = EnumMessage.ERROR.GetDescription();
            }
            return response;
        }
    }
}
