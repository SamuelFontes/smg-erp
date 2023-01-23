using Azure;
using Microsoft.Extensions.Logging;
using Products.Domain.IService;
using Products.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly NightDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(NightDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // NT/TODO: There's few things on this code that i really want to change 
        // The first and most important one is make some methods here more easier to understand
        // Also do a better error troubleshooting would be really usefull (right now just making a better catch is already enough)
        // Change the remove method to a update where it turns the Active column to 0
        // Probably make this layer able to use Dapper too, so we can run procedures which is a must to-go thing.
        // Anyways ive got alot of stuff that i want to change here before going to the frontend part but i dont have enough time right now
        public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            List<T> response = null;
            try
            {
                response = _context.Set<T>().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Route('${GetType().FullName + "." + MethodBase.GetCurrentMethod().DeclaringType.Name.Substring(1).Split('>')[0]}') LogError", ex);
                throw ex;
            }
            return response;
        }
        public async Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            T response = null;
            try
            {
                response = _context.Set<T>().Where(predicate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Route('${GetType().FullName + "." + MethodBase.GetCurrentMethod().DeclaringType.Name.Substring(1).Split('>')[0]}') LogError", ex);
                throw ex;
            }
            return response;
        }
        public async Task<T> Add<T>(T model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Route('${GetType().FullName + "." + MethodBase.GetCurrentMethod().DeclaringType.Name.Substring(1).Split('>')[0]}') LogError", ex);
                throw ex;
            }
            return model;
        }
        public async Task<bool> Update<T>(T model)
        {
            try
            {
                _context.Update(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Route('${GetType().FullName + "." + MethodBase.GetCurrentMethod().DeclaringType.Name.Substring(1).Split('>')[0]}') LogError", ex);
                throw ex;
            }
            return true;
        }
        public async Task<bool> Delete<T>(T model)
        {
            try
            {
                _context.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Route('${GetType().FullName + "." + MethodBase.GetCurrentMethod().DeclaringType.Name.Substring(1).Split('>')[0]}') LogError", ex);
                throw ex;
            }
            return true;
        }
    }
}
