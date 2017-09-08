using System.Net;
using System.Web.Http;
using Domain.Models;
using System.Net.Http;
using System.Web.Http.Cors;
using Infra.Repositories;
using Aplication.Interface;
using Aplication;
using Domain.Services;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class ProductsController : ApiController
    {
        //private Context db = new Context();
        private readonly IProductAppService _produtoRepository;
        private readonly ICategoryAppService _categoryRepository;

        public ProductsController(IProductAppService produtoRepository, ICategoryAppService categoryRepository)
        {
            _produtoRepository = produtoRepository;
            _categoryRepository = categoryRepository;
        }

        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            var result = _produtoRepository.GetAll();
            //var result = db.Produtos.Include("Category").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            var result = _categoryRepository.GetAll();
            //var result = db.Categories.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetProductsByCategories(int categoryId)
        {
            var result = _produtoRepository.GetProductByCategory(categoryId);
            //var result = db.Products.Include("Category").Where(x => x.CategoryId == categoryId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                _produtoRepository.Add(product);
                //db.Products.Add(product);
                //db.SaveChanges();
                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o produto");
            }
        }

        [HttpPatch]
        [Route("products")]
        public HttpResponseMessage PatchProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                _produtoRepository.Update(product);
                //db.Entry<Produto>(produto).State = EntityState.Modified;
                //db.SaveChanges();
                var result = product;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar o produto");
            }
        }

        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProduct(Product produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                _produtoRepository.Update(produto);
                //db.Entry<Produto>(produto).State = EntityState.Modified;
                //db.SaveChanges();
                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar o produto");
            }
        }

        [HttpDelete]
        [Route("products")]
        public HttpResponseMessage DeleteProduct(int productId)
        {
            if (productId == 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                _produtoRepository.Remove(productId);
                //db.Produtos.Remove(db.Produtos.Find(produtoId));
                //db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Produto apagado com sucesso");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir o produto");
            }
        }

        protected override void Dispose(bool disposing)
        {
            _produtoRepository.Dispose();
            _categoryRepository.Dispose();
        }
    }
}