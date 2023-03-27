var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/test", () =>
{
    var syntaxString = @"
                using System;
                using System.Diagnostics;
                using System.IO;
                namespace RoslynCompileSample
                {
                    public class Writer
                    {
                        public void Write(string message)
                        {
                            string[] lines =
                            {
                                  " + "\"First line\", \"Second line\", \"Third line\" " + @",
                                  message
                            };

                            File.WriteAllLines(" + "\"C:\\\\New folder\\\\WriteLines.txt\"" + @", lines);
                        }
                    }
                }";
    return syntaxString;
})
.WithName("GetScript");

app.Run();
