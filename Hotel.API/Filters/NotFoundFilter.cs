using Autofac.Core;
using Hotel.Core.DTOs;
using Hotel.Core.Models;
using Hotel.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Hotel.API.Filters
{
    public class NotFoundFilter<T, DTO> : IAsyncActionFilter where T : BaseEntity where DTO : NoContentDTO
    {
        //null kontrolu yapcaz not found bulmak için bu sebeple  service çağırmamız lazım
        private readonly IServiceWithDTO<T, NoContentDTO> _serviceWithDTO;

        public NotFoundFilter(IServiceWithDTO<T, NoContentDTO> serviceWithDTO)
        {
            _serviceWithDTO = serviceWithDTO;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault(); //bu metod GetById metodunun parametresindeki ilk değeri alıyoryani id yi.
            if (idValue == null)
            {
                await next.Invoke(); //eğer nullsa sen yoluna devam et
                return;
            }

            var id = (int)idValue;
            var anyEntity = (await _serviceWithDTO.AnyAsync(x => x.Id == id)).Data;  //normalde eski projede dto dönmüyodu burda dto dönüyoz data koduyla eriştik.

            if (anyEntity) //eğer bu idye sahip entity varsa.
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDTO<NoContentDTO>.Fail(404, $"{typeof(T).Name}({id}) not found."));
        }
    }
}