using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Modules.Utilities;
public static class SwaggerExtension
{
    /// <summary>
    /// 引入專案程式碼所產出的 XML 程式碼註解, 專案設定檔 *.csproj 需設定
    /// GenerateDocumentationFile = true
    /// </summary>
    /// <param name="options"></param>
    public static void IncludeBaseDirXmlComments(this SwaggerGenOptions options)
    {
        // 以目前執行的目錄, 載入所有已 compiler 出的程式碼註解
        string path = AppContext.BaseDirectory;
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        FileInfo[] files = directoryInfo.GetFiles();
        foreach (FileInfo fileInfo in files)
        {
            if (string.Compare(fileInfo.Extension, ".xml", true) == 0)
            {
                options.IncludeXmlComments(fileInfo.FullName);
            }
        }
    }

    /// <summary>
    /// 
    /// GenerateDocumentationFile = true
    /// </summary>
    /// <param name="options"></param>
    public static void AddSecurityDefinition(this SwaggerGenOptions options)
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. <br/> 
                                    Enter 'Bearer' [space] and then your token in the text input below.<br/>",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT"
        });

    }

    /// <summary>
    /// 
    /// GenerateDocumentationFile = true
    /// </summary>
    /// <param name="options"></param>
    public static void AddSecurityRequirement(this SwaggerGenOptions options)
    {
        options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });
    }
}