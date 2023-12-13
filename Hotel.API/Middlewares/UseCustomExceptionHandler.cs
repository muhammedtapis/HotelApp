using Hotel.Core.DTOs;
using Hotel.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Hotel.API.Middlewares
{
    //program.cs dosyasındak var app taki app a extension yazıyoruz.onun türü IApplicationBuilder
    //aktif hale getir daha sonra program.cs dosyasında.
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                //run sonlandırıcı middleware burdan sonra request geriye döner.
                configure.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>(); //bu interface sayesinde uygulamada fırlatılan hatayı alıyorz

                    var statusCode = exceptionFeature?.Error switch //switch ile içine gir bu errorun
                    {
                        ClientSideException => 400, //eğer burdan gelen hata clientSideExceptionsa bu hatakoduna 400 ata.
                        NotFoundException => 404,  //notfound ise 404 ata bunu da biz oluşturduk.
                        _ => 500  //başka bi hataysa default 500 ata.
                    };

                    context.Response.StatusCode = statusCode;

                    //response oluşturduk customDTO verdik ama bu bize tip veriyor bunu jsona serialize etmemiz gerek sonra
                    var response = CustomResponseDTO<NoContentDTO>.Fail(statusCode, exceptionFeature?.Error.Message);

                    //serialize
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}