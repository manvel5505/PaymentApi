namespace WebApplication52.Presentation.Middleware
{
    public static class ApplicationBuilder
    {
        public static IApplicationBuilder UseBuilder(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseCors("AllowFew");

            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            return app;
        }
    }
}
